using System;
using System.Configuration;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using KAutoHelper;

namespace LDBot
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public FormMain()
        {
            InitializeComponent();
            Helper.onUpdateMainStatus += ((stt) => updateStatus(stt));
            Helper.onErrorMessage += ((err) => showError(err));
            Helper.onUpdateLDStatus += ((ldIndex, stt) => updateLDStatus(ldIndex, stt));
            Helper.onWriteLog += ((log) => writeLog(log));
        }

        private void loadConfig()
        {
            lbl_BrowseLDFolder.Text = ConfigurationManager.AppSettings["LDPath"];
            ADBHelper.SetADBFolderPath(ConfigurationManager.AppSettings["LDPath"]);
            txt_DefaultLDWidth.Value = ConfigurationManager.AppSettings["DefaultWidth"] != null ? Decimal.Parse(ConfigurationManager.AppSettings["DefaultWidth"]) : 240;
            txt_DefaultLDHeight.Value = ConfigurationManager.AppSettings["DefaultHeight"] != null ? Decimal.Parse(ConfigurationManager.AppSettings["DefaultHeight"]) : 360;
        }

        private void updateStatus(string stt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.updateStatus(stt)));
            }
            else
            {
                if (stt.Length > 0)
                    stt_main.Text = stt;
            }
        }

        private void showError(Exception err)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.showError(err)));
            }
            else
            {
                    MessageBox.Show(string.Format("{0}\nInner: {1}\nSource: {2}", err.Message, err.InnerException?.ToString(), err.Source), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateLDStatus(int ldIndex, string status)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => updateLDStatus(ldIndex, status)));
            }    
            else
            {
                ListViewItem[] listViewItemArray = this.list_Emulator.Items.Find(ldIndex.ToString(), false);
                if(listViewItemArray.Length != 0)
                {
                    listViewItemArray[0].SubItems[2].Text = status;
                }    
            }    
        }

        private void writeLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => writeLog(log)));
            }
            else
            {
                rtb_log.AppendText(string.Format("{0}{1}", log.Trim(), Environment.NewLine));
                rtb_log.ScrollToCaret();
            }    
        }

        private void loadEmulatorListView()
        {
            try
            {
                LDManager.getAllLD();
                foreach (LDEmulator ld in LDManager.listEmulator)
                {
                    if (!this.list_Emulator.Items.ContainsKey(ld.Index.ToString()))
                    {
                        ListViewItem listViewItem = new ListViewItem(ld.Index.ToString())
                        {
                            Name = ld.Index.ToString(),
                            SubItems = {
                            ld.Name,
                            ld.isRunning ? "Running" : "Stop"
                        },
                            UseItemStyleForSubItems = false
                        };
                        listViewItem.Tag = ld;
                        this.list_Emulator.Items.Add(listViewItem);
                        JToken configFileContent = JToken.Parse(File.ReadAllText(string.Format("{0}\\vms\\config\\leidian{1}.config", ConfigurationManager.AppSettings["LDPath"], ld.Index)));
                        bool isNeedEdit = false;
                        if (configFileContent["basicSettings.adbDebug"] == null || configFileContent["basicSettings.adbDebug"].ToString() == "0")
                        {
                            configFileContent["basicSettings.adbDebug"] = 1;
                            isNeedEdit = true;
                        }
                        if (configFileContent["advancedSettings.resolution"] == null || configFileContent["advancedSettings.resolution"]["width"].ToString() != ConfigurationManager.AppSettings["DefaultWidth"])
                        {
                            configFileContent["advancedSettings.resolution"] = JToken.Parse(string.Format("{{ \"width\": {0}, \"height\": {1} }}", ConfigurationManager.AppSettings["DefaultWidth"], ConfigurationManager.AppSettings["DefaultHeight"]));
                            configFileContent["advancedSettings.resolutionDpi"] = 120;
                            //configFileContent["basicSettings.width"] = -1;
                            //configFileContent["basicSettings.height"] = -1;
                            //configFileContent["basicSettings.realHeigh"] = -1;
                            //configFileContent["basicSettings.realWidth"] = -1;
                            isNeedEdit = true;
                        }
                        if(configFileContent["basicSettings.rightToolBar"] == null || bool.Parse(configFileContent["basicSettings.rightToolBar"].ToString()) == true)
                        {
                            configFileContent["basicSettings.rightToolBar"] = false;
                            isNeedEdit = true;
                        }    
                        if (isNeedEdit)
                        {
                            string rs = configFileContent.ToString();
                            File.WriteAllText(string.Format("{0}\\vms\\config\\leidian{1}.config", ConfigurationManager.AppSettings["LDPath"], ld.Index), rs);
                        }    
                    }
                }
            }
            catch(Exception e)
            {
                showError(e);
             }
}

        private void lbl_BrowseLDFolder_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lbl_BrowseLDFolder.Text = folderBrowserDialog1.SelectedPath;
                if (!File.Exists(lbl_BrowseLDFolder.Text + "\\ldconsole.exe"))
                {
                    showError(new Exception("Can not find ldconsole.exe. Please browse LD Player again!"));
                    btn_SaveGeneralConfig.Enabled = false;
                }
                else
                {
                    updateStatus("File ldconsole.exe found.");
                    btn_SaveGeneralConfig.Enabled = true;
                }
            }    
        }

        private void btn_SaveGeneralConfig_Click(object sender, EventArgs e)
        {
            if (lbl_BrowseLDFolder.Text.Length > 0)
            {
                Helper.AddOrUpdateAppSettings("LDPath", lbl_BrowseLDFolder.Text);
                ADBHelper.SetADBFolderPath(lbl_BrowseLDFolder.Text);
            }
            if(txt_DefaultLDWidth.Value > 0)
                Helper.AddOrUpdateAppSettings("DefaultWidth", txt_DefaultLDWidth.Value.ToString());
            if (txt_DefaultLDHeight.Value > 0)
                Helper.AddOrUpdateAppSettings("DefaultHeight", txt_DefaultLDHeight.Value.ToString());
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Prompt prompt = new Prompt("Input new LD Player name", "Create New LDPlayer"))
            {
                if (prompt.Result.Length > 0)
                {
                    LDManager.createLD(prompt.Result);
                    loadEmulatorListView();
                }
            }
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            loadConfig();
            loadEmulatorListView();
            if(!Directory.Exists(ConfigurationManager.AppSettings["LDPath"] + "\\Scripts"))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["LDPath"] + "\\Scripts");
            }    
        }

        private void featuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ft = File.ReadAllText("DATA\\features.txt");
            MessageBox.Show(ft, "Features",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private async void runSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                foreach (object selectedLD in list_Emulator.SelectedItems)
                {
                    LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                    new Task(delegate
                    {
                        LDManager.runLD(ld);
                    }).Start();
                    await Task.Delay(5000);
                }
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quitAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LDManager.quitAll();
        }

        private void list_Emulator_DoubleClick(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                SetForegroundWindow(ld.TopHandle);
            }
        }

        private void list_Emulator_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var selectedItem = list_Emulator.FocusedItem;
                if(selectedItem != null && selectedItem.Bounds.Contains(e.Location))
                {
                    listLDContextMenuStrip1.Show(Cursor.Position);
                }    
            }    
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                new Task(delegate
                {
                    LDManager.runLD(ld);
                }).Start();
            }
        }

        private void rebootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.restartLD(ld);
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.quitLD(ld.Index);
            }
        }

        private void cloneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                using (Prompt prompt = new Prompt("Input new LD Player name", "Clone LDPlayer"))
                {
                    if (prompt.Result.Length > 0)
                    {
                        LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                        LDManager.cloneLD(prompt.Result, ld.Index, ld.Name);
                        loadEmulatorListView();
                    }
                }
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void changeInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.changeLDInfo(ld.Index);
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this player?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (list_Emulator.SelectedItems.Count > 0)
                {
                    LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                    LDManager.removeLD(ld.Index);
                    list_Emulator.SelectedItems[0].Remove();
                }
                else
                {
                    showError(new Exception("Select source player first!"));
                }
            }
        }

        private void loadScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.loadScript(ld);
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void startScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.startScript(ld);
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void loadScriptSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                foreach (object selectedLD in list_Emulator.SelectedItems)
                {
                    LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                    LDManager.loadScript(ld);
                }
            }
        }

        private void startScriptSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                foreach (object selectedLD in list_Emulator.SelectedItems)
                {
                    LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                    LDManager.startScript(ld);
                }
            }
        }

        private void list_Emulator_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                if (ld != null)
                    updateStatus(ld.TopHandle.ToString());
            }
            catch{ }
        }

        private void stopScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.stopScript(ld);
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }

        private void stopScriptSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                foreach (object selectedLD in list_Emulator.SelectedItems)
                {
                    LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                    LDManager.stopScript(ld);
                }
            }
        }

        private void installAPKSelectedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Prompt prompt = new Prompt("Select APK file to install", "Install APK"))
            {
                if (prompt.Result.Length > 0)
                {
                    if (list_Emulator.SelectedItems.Count > 0)
                    {
                        foreach (object selectedLD in list_Emulator.SelectedItems)
                        {
                            LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                            LDManager.installAPK(ld.Index, prompt.Result);
                        }
                    }
                }
            }
        }

        private void installAPKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Prompt prompt = new Prompt("Select APK file to install", "Install APK","Drag and drop APK here to install"))
            {
                if (prompt.Result.Length > 0)
                {
                    if (list_Emulator.SelectedItems.Count > 0)
                    {
                        LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                        LDManager.installAPK(ld.Index, prompt.Result);
                    }
                }
            }
        }

        private void changeProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Prompt prompt = new Prompt("Input HTTP proxy info. Ex: proxy:port", "Change Proxy"))
            {
                if (list_Emulator.SelectedItems.Count > 0)
                {
                    LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                    LDManager.changeProxy(ld, prompt.Result);
                }
            }
        }

        private void changeProxyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Prompt prompt = new Prompt("Input HTTP proxy info. Ex: proxy:port", "Change Proxy"))
            {
                if (list_Emulator.SelectedItems.Count > 0)
                {     
                    foreach (object selectedLD in list_Emulator.SelectedItems)
                    {
                        LDEmulator ld = ((ListViewItem)selectedLD).Tag as LDEmulator;
                        LDManager.changeProxy(ld, prompt.Result);
                    }
                }
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                Helper.runCMD("explorer.exe", ld.ScriptFolder);
            }
        }
    }
}
