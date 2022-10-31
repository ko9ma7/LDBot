using System;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace LDBot
{
    public class Helper
    {
        public static event dlgUpdateMainStatus onUpdateMainStatus;
        public static event dlgErrorMessage onErrorMessage;
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                raiseOnUpdateMainStatus(String.Format("Configuration {0} = {1} has been saved", key, value));
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                raiseOnUpdateMainStatus("Error writing app settings");
            }
        }

        public static string CreateRandomStringNumber(int lengText, Random rd = null)
        {
            string text = "";
            bool flag = rd == null;
            bool flag2 = flag;
            if (flag2)
            {
                rd = new Random();
            }
            string text2 = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < lengText; i++)
            {
                text += text2[rd.Next(0, text2.Length)].ToString();
            }
            return text;
        }

        public static string CreateRandomNumber(int leng, Random rd = null)
        {
            string text = "";
            bool flag = rd == null;
            bool flag2 = flag;
            if (flag2)
            {
                rd = new Random();
            }
            string text2 = "0123456789";
            for (int i = 0; i < leng; i++)
            {
                text += text2[rd.Next(0, text2.Length)].ToString();
            }
            return text;
        }

        public static string Md5Encode(string text, string type = "X2")
        {
            MD5 md = MD5.Create();
            byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString(type));
            }
            return stringBuilder.ToString();
        }

        public static void raiseOnUpdateMainStatus(string stt)
        {
            if (onUpdateMainStatus == null)
                return;
            else
                onUpdateMainStatus(stt);
        }

        public static void raiseOnErrorMessage(Exception err)
        {
            if (onErrorMessage == null)
                return;
            else
                onErrorMessage(err);
        }
    }

    public class Prompt : IDisposable
    {
        private Form prompt { get; set; }
        public string Result { get; }

        public Prompt(string text, string caption)
        {
            Result = ShowDialog(text, caption);
        }
        //use a using statement
        private string ShowDialog(string text, string caption)
        {
            prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 265 };
            Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public void Dispose()
        {
            //See Marcus comment
            if (prompt != null)
            {
                prompt.Dispose();
            }
        }
    }
}
