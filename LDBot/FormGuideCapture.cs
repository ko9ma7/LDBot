using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDBot
{
    public partial class FormGuideCapture : Form
    {
        public LDEmulator ld { get; set; }
        private string[] imgFiles;
        public FormGuideCapture(LDEmulator _ld)
        {
            ld = _ld;
            InitializeComponent();
        }

        private void loadGuideImages()
        {
            if (Directory.Exists(ld.ScriptFolder + "\\Guide"))
            {
                imgFiles = Directory.GetFiles(ld.ScriptFolder + "\\Guide", "*.png");
                lbl_ImageCount.Text = string.Format("This script has {0} tutorial image(s)", imgFiles.Length);
                foreach(string img in imgFiles)
                {
                    ListViewItem listViewItem = new ListViewItem(Helper.getFileNameByPath(img))
                    {
                        Name = Helper.getFileNameByPath(img),
                        UseItemStyleForSubItems = false
                    };
                    listViewItem.Tag = img;
                    this.lst_ImgGuide.Items.Add(listViewItem);
                }    
            }
            else
            {
                Helper.raiseOnUpdateLDStatus(ld.Index, "This script has no tutorial images");
            }    
        }

        private void FormGuideCapture_Load(object sender, EventArgs e)
        {
            loadGuideImages();
        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            if (lst_ImgGuide.SelectedItems.Count > 0)
            {
                string img = lst_ImgGuide.SelectedItems[0].Tag as string;
                ld.botAction.CaptureGuide(Helper.getFileNameByPath(img));
            }
        }

        private void lst_ImgGuide_MouseClick(object sender, MouseEventArgs e)
        {
            if (lst_ImgGuide.SelectedItems.Count > 0)
            {
                string img = lst_ImgGuide.SelectedItems[0].Tag as string;
                pic_CurrentView.Image = Image.FromFile(img);
            }
        }
    }
}
