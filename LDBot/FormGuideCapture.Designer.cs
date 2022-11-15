
namespace LDBot
{
    partial class FormGuideCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuideCapture));
            this.btn_Capture = new System.Windows.Forms.Button();
            this.pic_CurrentView = new System.Windows.Forms.PictureBox();
            this.lbl_ImageCount = new System.Windows.Forms.Label();
            this.lst_ImgGuide = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pic_CurrentView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(272, 365);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(75, 23);
            this.btn_Capture.TabIndex = 1;
            this.btn_Capture.Text = "Capture";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // pic_CurrentView
            // 
            this.pic_CurrentView.Location = new System.Drawing.Point(76, 12);
            this.pic_CurrentView.Name = "pic_CurrentView";
            this.pic_CurrentView.Size = new System.Drawing.Size(530, 340);
            this.pic_CurrentView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CurrentView.TabIndex = 0;
            this.pic_CurrentView.TabStop = false;
            // 
            // lbl_ImageCount
            // 
            this.lbl_ImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ImageCount.AutoSize = true;
            this.lbl_ImageCount.Location = new System.Drawing.Point(12, 370);
            this.lbl_ImageCount.Name = "lbl_ImageCount";
            this.lbl_ImageCount.Size = new System.Drawing.Size(35, 13);
            this.lbl_ImageCount.TabIndex = 2;
            this.lbl_ImageCount.Text = "label1";
            this.lbl_ImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lst_ImgGuide
            // 
            this.lst_ImgGuide.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lst_ImgGuide.HideSelection = false;
            this.lst_ImgGuide.Location = new System.Drawing.Point(5, 12);
            this.lst_ImgGuide.Name = "lst_ImgGuide";
            this.lst_ImgGuide.Size = new System.Drawing.Size(65, 340);
            this.lst_ImgGuide.TabIndex = 3;
            this.lst_ImgGuide.UseCompatibleStateImageBehavior = false;
            this.lst_ImgGuide.View = System.Windows.Forms.View.Details;
            this.lst_ImgGuide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lst_ImgGuide_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Img Index";
            // 
            // FormGuideCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 397);
            this.Controls.Add(this.lst_ImgGuide);
            this.Controls.Add(this.lbl_ImageCount);
            this.Controls.Add(this.btn_Capture);
            this.Controls.Add(this.pic_CurrentView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGuideCapture";
            this.Text = "Capture Guide";
            this.Load += new System.EventHandler(this.FormGuideCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_CurrentView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_CurrentView;
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.Label lbl_ImageCount;
        private System.Windows.Forms.ListView lst_ImgGuide;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}