using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDBot
{
    public partial class FormLDHardware : Form
    {
        private List<LDEmulator> _ld;
        public FormLDHardware(List<LDEmulator> ld)
        {
            InitializeComponent();
            _ld = ld;
        }

        private void btn_saveLDHardware_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.raiseOnWriteLog(string.Format("CPU: {0} - RAM: {1} - Width: {2} - Height: {3} - DPI: {4}", txt_CPU.Text, txt_RAM.Text, txt_Width.Text, txt_Height.Text, txt_DPI.Text));
                foreach (LDEmulator ld in _ld)
                {
                    if (!ld.isRunning)
                    {
                        string command = string.Concat(new string[]
                        {
                        "modify --index ", ld.Index.ToString(),
                        " --resolution ", txt_Width.Text,",", txt_Height.Text,",", txt_DPI.Text,
                        " --cpu ", txt_CPU.Text, " --memory ", txt_RAM.Text
                        });
                        LDManager.executeLdConsole(command);
                        Helper.raiseOnUpdateLDStatus(ld.Index, "Hardware change OK");
                    }
                    else
                    {
                        Helper.raiseOnUpdateLDStatus(ld.Index, "Shutdown first");
                    }
                }
                
            }
            catch(Exception ex)
            {
                Helper.raiseOnErrorMessage(ex);
            }
            finally
            {
                this.Close();
            }
		}
    }
}
