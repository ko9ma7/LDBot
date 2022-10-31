using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LDBot
{
	public class LDManager
	{
		private static string ldConsole = ConfigurationManager.AppSettings["LDPath"] + "\\ldconsole.exe";

		public static List<LDEmulator> listEmulator = new List<LDEmulator>();

		public static void getAllLD()
		{
			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo
				{
					FileName = ldConsole,
					Arguments = "list2",
					CreateNoWindow = true,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden,
					RedirectStandardInput = true,
					RedirectStandardOutput = true
				};
				process.Start();
				process.WaitForExit(3000);
				string[] result = process.StandardOutput.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string line in result)
				{
					string[] ldInfo = line.Split(',');
					if (!listEmulator.Any(ld => ld.Index == int.Parse(ldInfo[0])))
					{
						listEmulator.Add(new LDEmulator(
							int.Parse(ldInfo[0]),
							ldInfo[1],
							new IntPtr(Convert.ToInt32(ldInfo[2], 16)),
							new IntPtr(Convert.ToInt32(ldInfo[3], 16)),
							int.Parse(ldInfo[4]) == 1,
							int.Parse(ldInfo[5]),
							int.Parse(ldInfo[6])
						));
					}
				}
			}
			catch (Exception e)
			{
				Helper.raiseOnErrorMessage(e);
			}
		}

		public static void createLD(string name)
		{
			try
			{
				if (name.Length > 0)
				{
					LDManager.executeLdConsole(string.Format("add --name \"{0}\"", name));
					Helper.raiseOnUpdateMainStatus(string.Format("Create new LD Player \"{0}\" successfully", name));
				}
			}
			catch (Exception e)
			{
				Helper.raiseOnErrorMessage(e);
			}
		}

		public static void cloneLD(string name, int fromIndex, string fromName)
		{
			try
			{
				if (name.Length > 0)
				{
					LDManager.executeLdConsole(string.Format("copy --name \"{0}\" --from {1}", name, fromIndex));
					Helper.raiseOnUpdateMainStatus(string.Format("Clone from \"{0}\" to \"{1}\" successfully", fromName, name));
				}
			}
			catch (Exception e)
			{
				Helper.raiseOnErrorMessage(e);
			}
		}

		public static void changeLDInfo(int index)
		{
			try
			{

				Random random = new Random();
				JToken arrDeviceInfo = JToken.Parse(File.ReadAllText("DATA/deviceinfo.json"));
				JToken deviceInfo = arrDeviceInfo[random.Next(0, arrDeviceInfo.Count() - 1)];
				JToken manufacturer = deviceInfo["manufacturer"];
				JToken models = deviceInfo["models"];
				JToken model = models[random.Next(0, models.Count() - 1)];
				JToken arrAreaCode = JToken.Parse(File.ReadAllText("DATA/areacode.json"));
				JToken country = arrAreaCode[0];
				JToken areaCodes = country["areacode"];
				JToken areaCode = areaCodes[random.Next(0, areaCodes.Count() - 1)];
				string imei = "86516602" + Helper.CreateRandomNumber(7, random);
				string pNumber = "1" + areaCode.ToString() + Helper.CreateRandomNumber(7, random);
				string imsi = "46000" + Helper.CreateRandomNumber(10, random);
				string simserial = "898600" + Helper.CreateRandomNumber(14, random);
				string androidid = Helper.Md5Encode(Helper.CreateRandomStringNumber(32, random), "x2").Substring(random.Next(0, 16), 16);

				LDManager.executeLdConsole(string.Concat(new object[]
				{
					"modify --index ", index,
					" --imei ", imei,
					" --model \"", model.ToString(),
					"\" --manufacturer ", manufacturer.ToString(),
					" --pnumber ", pNumber,
					" --imsi ", imsi,
					" --simserial ", simserial,
					" --androidid ", androidid,
					" --resolution 320,480,120",
					" --cpu 1 --memory 1024",
					" --mac auto"
				}));

				Helper.raiseOnUpdateMainStatus(string.Format("New info: {0}, {1}, IMEI: {2}, Phone: {3}", manufacturer, model, imei, pNumber));
			}
			catch (Exception e)
			{
				Helper.raiseOnErrorMessage(e);
			}
		}

		public static void removeLD(int index)
        {
			try
            {
				LDManager.executeLdConsole(string.Format("remove --index {0}", index));
				LDManager.listEmulator.RemoveAt(LDManager.listEmulator.FindIndex((LDEmulator l) => l.Index == index));
				Helper.raiseOnUpdateMainStatus("Player deleted successful");
			}
			catch(Exception e)
            {
				Helper.raiseOnErrorMessage(e);
			}
        }

		public static void runLD(int index)
        {
			try
            {
				LDManager.executeLdConsole("launch --index " + index);
				Helper.raiseOnUpdateMainStatus("Launch player " + index);
            }
			catch(Exception e)
            {
				Helper.raiseOnErrorMessage(e);
			}			
        }

		public static void quitAll()
        {
			try
			{
				LDManager.executeLdConsole("quitall");
			}
			catch (Exception e)
			{
				Helper.raiseOnErrorMessage(e);
			}
		}

		public static void executeLdConsole(string cmd)
		{
			Process process = new Process();
			process.StartInfo.FileName = ldConsole;
			process.StartInfo.Arguments = cmd;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.EnableRaisingEvents = true;
			process.Start();
			process.WaitForExit();
			process.Close();
		}
	}
}
