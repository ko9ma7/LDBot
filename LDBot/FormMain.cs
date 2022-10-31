using System;
using System.Configuration;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LDBot
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Helper.onUpdateMainStatus += ((stt) => updateStatus(stt));
            Helper.onErrorMessage += ((err) => showError(err));
        }

        private void loadConfig()
        {
            lbl_BrowseLDFolder.Text = ConfigurationManager.AppSettings["LDPath"];
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
                            configFileContent["basicSettings.width"] = 0;
                            configFileContent["basicSettings.height"] = 0;
                            configFileContent["basicSettings.realHeigh"] = 0;
                            configFileContent["basicSettings.realWidth"] = 0;
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
                Helper.AddOrUpdateAppSettings("LDPath", lbl_BrowseLDFolder.Text);
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
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void featuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ft = File.ReadAllText("DATA\\features.txt");
            MessageBox.Show(ft, "Features",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void changeInfoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this player?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void runSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Emulator.SelectedItems.Count > 0)
            {
                LDEmulator ld = list_Emulator.SelectedItems[0].Tag as LDEmulator;
                LDManager.runLD(ld.Index);
            }
            else
            {
                showError(new Exception("Select source player first!"));
            }
        }
    }
}
