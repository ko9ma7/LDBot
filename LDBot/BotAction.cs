using KAutoHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using xNet;

namespace LDBot
{

    public class BotAction
    {
        protected LDEmulator _ld;
        protected bool isRunning;
        private Random rd;
        public BotAction(LDEmulator ld)
        {
            if(ld != null)
                _ld = ld;
            rd = new Random();
            isRunning = false;
        }

        #region Virtual Function
        public virtual void Init()
        {
        }

        public virtual void Start() { }

        public virtual void Stop()
        {
            isRunning = false;
        }
        #endregion

        #region Bot Function
        protected void setStatus(string stt)
        {
            if (stt.Length > 0)
                Helper.raiseOnUpdateLDStatus(_ld.Index, stt);
        }
        protected bool findAndClick(string imgPath, double similarPercent = 0.9, int xPlus = 0, int yPlus = 0, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0)
        {
            if (!isRunning)
                return false;
            Bitmap img = (Bitmap)Image.FromFile(imgPath);
            Bitmap screen = (Bitmap)CaptureHelper.CaptureWindow(_ld.BindHandle);
            bool flag = startCropX != 0 || startCropY != 0 || cropWidth != 0 || cropHeight != 0;
            if (flag)
            {
                screen = CaptureHelper.CropImage(screen, new Rectangle(startCropX, startCropY, cropWidth, cropHeight));
            }
            Point? point = ImageScanOpenCV.FindOutPoint(screen, img, similarPercent);
            bool flag2 = point != null;
            bool result;
            if (flag2)
            {
                setStatus("Image found and click");
                int Xmore = rd.Next(3);
                int Ymore = rd.Next(3);
                //AutoControl.SendClickOnPosition(_ld.TopHandle, point.Value.X + Xmore + xPlus + startCropX, point.Value.Y + Ymore + yPlus + startCropY, EMouseKey.LEFT, 1);
                ADBHelper.Tap(_ld.DeviceID, point.Value.X + Xmore + xPlus + startCropX, point.Value.Y + Ymore + yPlus + startCropY);
                result = true;
            }
            else
            {
                setStatus("Image not found");
                result = false;
            }
            screen.Dispose();
            img.Dispose();
            return result;
        }

        protected bool findImage(string imgPath, double similarPercent = 0.9, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0)
        {
            if (!isRunning)
                return false;
            Bitmap img = (Bitmap)Image.FromFile(imgPath);
            Bitmap screen = (Bitmap)CaptureHelper.CaptureWindow(_ld.BindHandle);
            bool flag = startCropX != 0 || startCropY != 0 || cropWidth != 0 || cropHeight != 0;
            if (flag)
            {
                screen = CaptureHelper.CropImage(screen, new Rectangle(startCropX, startCropY, cropWidth, cropHeight));
            }
            bool result = ImageScanOpenCV.FindOutPoint(screen, img, similarPercent) != null;
            if (result)
                setStatus("Image found");
            else
                setStatus("Image not found");
            screen.Dispose();
            img.Dispose();
            return result;
        }

        protected void click(int x, int y, int count = 1)
        {
            if (!isRunning)
                return;
            ADBHelper.Tap(_ld.DeviceID, x, y, count);
            setStatus(string.Format("Click at {0}:{1}", x, y));
        }

        protected void clickP(double x, double y, int count = 1)
        {
            if (!isRunning)
                return;
            ADBHelper.TapByPercent(_ld.DeviceID, x, y, count);
            setStatus(string.Format("Click at {0:0.00}%:{1:0.00}%", x, y));
        }

        protected void swipe(int startX, int startY, int stopX, int stopY, int swipeTime = 300)
        {
            if (!isRunning)
                return;
            ADBHelper.Swipe(_ld.DeviceID, startX, startY, stopX, stopY, swipeTime);
            setStatus(string.Format("Swipe from {0}:{1} to {2}:{3}", startX, startY, stopX, stopY));
        }

        protected void swipeP(double startX, double startY, double stopX, double stopY, int swipeTime = 300)
        {
            if (!isRunning)
                return;
            ADBHelper.SwipeByPercent(_ld.DeviceID, startX, startY, stopX, stopY, swipeTime);
            setStatus(string.Format("Swipe from {0:0.00}%:{1:0.00}% to {2:0.00}%:{3:0.00}%", startX, startY, stopX, stopY));
        }

        protected void inputKey(ADBKeyEvent key)
        {
            if (!isRunning)
                return;
            ADBHelper.Key(_ld.DeviceID, key);
            setStatus("Press key " + key.ToString());
        }

        protected void inputText(string txt)
        {
            if (!isRunning)
                return;
            ADBHelper.InputText(_ld.DeviceID, txt);
            setStatus("Input: " + txt);
        }

        protected void clickAndHold(int x, int y, int duration = 500)
        {
            if (!isRunning)
                return;
            ADBHelper.LongPress(_ld.DeviceID, x, y, duration);
        }

        protected void delay(double ms)
        {
            if (!isRunning)
                return;
            ADBHelper.Delay(ms);
        }

        protected List<string> getInstalledPackages()
        {
            if (!isRunning)
                return null;
            setStatus("Get installed packages");
            List<string> installedPackage = new List<string>();
            string[] results = Helper.runCMD(LDManager.adb, string.Format("-s {0} shell cmd package list package", _ld.DeviceID)).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string rs in results)
            {
                installedPackage.Add(rs.Replace("package:", "").Trim());
            }
            return installedPackage;
        }

        protected void writeLog(string log)
        {
            if (!isRunning)
                return;
            if (log.Length > 0)
                Helper.raiseOnWriteLog(log);
        }

        protected void runApp(string packageName)
        {
            if (!isRunning)
                return;
            setStatus("Run " + packageName);
            LDManager.executeLdConsole(string.Format("runapp --index {0} --packagename {1}",_ld.Index, packageName));
        }

        protected void killApp(string packageName)
        {
            if (!isRunning)
                return;
            setStatus("Kill " + packageName);
            LDManager.executeLdConsole(string.Format("killapp --index {0} --packagename {1}", _ld.Index, packageName));
        }

        protected void changeProxy(string proxyConfig = "")
        {
            if (proxyConfig.Length > 0)
            {
                _ld.isUseProxy = true;
            }
            else
            {
                _ld.isUseProxy = false;
            }
            _ld.Proxy = proxyConfig;
            LDManager.changeProxy(_ld, proxyConfig);
        }

        protected string getCurrentIP()
        {
            using (var request = new HttpRequest())
            {
                request.UserAgent = Http.ChromeUserAgent();
                if (_ld.isUseProxy)
                    request.Proxy = HttpProxyClient.Parse(_ld.Proxy);
                string content = request.Get("http://ip-api.com/json").ToString();
                var jsonStruct = new
                {
                    status = "",
                    country = "",
                    query = ""
                };
                var data = JsonConvert.DeserializeAnonymousType(content, jsonStruct);
                if (data.status == "success")
                    return data.query;
                return "";
            }
        }
        #endregion
    }
}