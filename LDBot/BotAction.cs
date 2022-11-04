using KAutoHelper;
using System;
using System.Drawing;
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

        public virtual void Init()
        {
        }

        public virtual void Start() { }

        public virtual void Stop()
        {
            isRunning = false;
        }

        protected void setStatus(string stt)
        {
            if (stt.Length > 0)
                Helper.raiseOnUpdateLDStatus(_ld.Index, stt);
        }
        protected bool findAndClick(string imgPath, double similarPercent = 0.9, int xPlus = 0, int yPlus = 0, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0)
        {
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
                setStatus(string.Format("Image {0} Found At {1}", imgPath, point.Value));
                int Xmore = rd.Next(3);
                int Ymore = rd.Next(3);
                //AutoControl.SendClickOnPosition(_ld.TopHandle, point.Value.X + Xmore + xPlus + startCropX, point.Value.Y + Ymore + yPlus + startCropY, EMouseKey.LEFT, 1);
                ADBHelper.Tap(_ld.DeviceID, point.Value.X + Xmore + xPlus + startCropX, point.Value.Y + Ymore + yPlus + startCropY);
                result = true;
            }
            else
            {
                setStatus(string.Format("Image {0} Not Found", imgPath));
                result = false;
            }
            screen.Dispose();
            img.Dispose();
            return result;
        }

        protected bool findImage(string imgPath, double similarPercent = 0.9, int startCropX = 0, int startCropY = 0, int cropWidth = 0, int cropHeight = 0)
        {
            Bitmap img = (Bitmap)Image.FromFile(imgPath);
            Bitmap screen = (Bitmap)CaptureHelper.CaptureWindow(_ld.BindHandle);
            bool flag = startCropX != 0 || startCropY != 0 || cropWidth != 0 || cropHeight != 0;
            if (flag)
            {
                screen = CaptureHelper.CropImage(screen, new Rectangle(startCropX, startCropY, cropWidth, cropHeight));
            }
            bool result = ImageScanOpenCV.FindOutPoint(screen, img, similarPercent) != null;
            screen.Dispose();
            img.Dispose();
            return result;
        }

        protected void click(int x, int y, int count = 1)
        {
            ADBHelper.Tap(_ld.DeviceID, x, y, count);
        }

        protected void clickP(double x, double y, int count = 1)
        {
            ADBHelper.TapByPercent(_ld.DeviceID, x, y, count);
        }

        protected void swipe(int startX, int startY, int stopX, int stopY, int swipeTime = 300)
        {
            ADBHelper.Swipe(_ld.DeviceID, startX, startY, stopX, stopY, swipeTime);
        }

        protected void swipeP(double startX, double startY, double stopX, double stopY, int swipeTime = 300)
        {
            ADBHelper.SwipeByPercent(_ld.DeviceID, startX, startY, stopX, stopY, swipeTime);
        }

        protected void inputKey(ADBKeyEvent key)
        {
            ADBHelper.Key(_ld.DeviceID, key);
        }

        protected void inputText(string txt)
        {
            ADBHelper.InputText(_ld.DeviceID, txt);
        }

        protected void clickAndHold(int x, int y, int duration = 500)
        {
            ADBHelper.LongPress(_ld.DeviceID, x, y, duration);
        }

        protected void delay(double ms)
        {
            ADBHelper.Delay(ms);
        }
    }
}
