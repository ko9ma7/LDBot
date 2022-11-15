
namespace LDBot
{
    partial class FormLDHardware
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CPU = new System.Windows.Forms.TextBox();
            this.txt_RAM = new System.Windows.Forms.TextBox();
            this.txt_Width = new System.Windows.Forms.TextBox();
            this.txt_Height = new System.Windows.Forms.TextBox();
            this.txt_DPI = new System.Windows.Forms.TextBox();
            this.lbl_LDName = new System.Windows.Forms.Label();
            this.btn_saveLDHardware = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPUs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "RAM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "DPI";
            // 
            // txt_CPU
            // 
            this.txt_CPU.Location = new System.Drawing.Point(60, 48);
            this.txt_CPU.Name = "txt_CPU";
            this.txt_CPU.Size = new System.Drawing.Size(72, 26);
            this.txt_CPU.TabIndex = 1;
            // 
            // txt_RAM
            // 
            this.txt_RAM.Location = new System.Drawing.Point(191, 48);
            this.txt_RAM.Name = "txt_RAM";
            this.txt_RAM.Size = new System.Drawing.Size(72, 26);
            this.txt_RAM.TabIndex = 1;
            // 
            // txt_Width
            // 
            this.txt_Width.Location = new System.Drawing.Point(60, 101);
            this.txt_Width.Name = "txt_Width";
            this.txt_Width.Size = new System.Drawing.Size(72, 26);
            this.txt_Width.TabIndex = 1;
            // 
            // txt_Height
            // 
            this.txt_Height.Location = new System.Drawing.Point(191, 101);
            this.txt_Height.Name = "txt_Height";
            this.txt_Height.Size = new System.Drawing.Size(72, 26);
            this.txt_Height.TabIndex = 1;
            // 
            // txt_DPI
            // 
            this.txt_DPI.Location = new System.Drawing.Point(55, 154);
            this.txt_DPI.Name = "txt_DPI";
            this.txt_DPI.Size = new System.Drawing.Size(72, 26);
            this.txt_DPI.TabIndex = 1;
            // 
            // lbl_LDName
            // 
            this.lbl_LDName.AutoSize = true;
            this.lbl_LDName.Location = new System.Drawing.Point(109, 14);
            this.lbl_LDName.Name = "lbl_LDName";
            this.lbl_LDName.Size = new System.Drawing.Size(51, 20);
            this.lbl_LDName.TabIndex = 2;
            this.lbl_LDName.Text = "label6";
            this.lbl_LDName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_saveLDHardware
            // 
            this.btn_saveLDHardware.Location = new System.Drawing.Point(97, 186);
            this.btn_saveLDHardware.Name = "btn_saveLDHardware";
            this.btn_saveLDHardware.Size = new System.Drawing.Size(75, 33);
            this.btn_saveLDHardware.TabIndex = 3;
            this.btn_saveLDHardware.Text = "Save";
            this.btn_saveLDHardware.UseVisualStyleBackColor = true;
            this.btn_saveLDHardware.Click += new System.EventHandler(this.btn_saveLDHardware_Click);
            // 
            // FormLDHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 231);
            this.Controls.Add(this.btn_saveLDHardware);
            this.Controls.Add(this.lbl_LDName);
            this.Controls.Add(this.txt_Height);
            this.Controls.Add(this.txt_RAM);
            this.Controls.Add(this.txt_DPI);
            this.Controls.Add(this.txt_Width);
            this.Controls.Add(this.txt_CPU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormLDHardware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLDHardware";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_CPU;
        private System.Windows.Forms.TextBox txt_RAM;
        private System.Windows.Forms.TextBox txt_Width;
        private System.Windows.Forms.TextBox txt_Height;
        private System.Windows.Forms.TextBox txt_DPI;
        private System.Windows.Forms.Label lbl_LDName;
        private System.Windows.Forms.Button btn_saveLDHardware;
    }
}