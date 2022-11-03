
namespace LDBot
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_LDEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stt_main = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Config = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_DefaultLDHeight = new System.Windows.Forms.NumericUpDown();
            this.txt_DefaultLDWidth = new System.Windows.Forms.NumericUpDown();
            this.btn_SaveGeneralConfig = new System.Windows.Forms.Button();
            this.lbl_BrowseLDFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.list_Emulator = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listLDContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScriptSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startScriptSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Config.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DefaultLDHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DefaultLDWidth)).BeginInit();
            this.listLDContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_LDEmulator,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_LDEmulator
            // 
            this.menu_LDEmulator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSelectedToolStripMenuItem,
            this.createNewToolStripMenuItem,
            this.quitAllToolStripMenuItem,
            this.loadScriptSelectedsToolStripMenuItem,
            this.startScriptSelectedsToolStripMenuItem,
            this.stopScriptSelectedsToolStripMenuItem});
            this.menu_LDEmulator.Name = "menu_LDEmulator";
            this.menu_LDEmulator.Size = new System.Drawing.Size(154, 25);
            this.menu_LDEmulator.Text = "LD Player Manager";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.featuresToolStripMenuItem,
            this.versionToolStripMenuItem,
            this.testToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // featuresToolStripMenuItem
            // 
            this.featuresToolStripMenuItem.Name = "featuresToolStripMenuItem";
            this.featuresToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.featuresToolStripMenuItem.Text = "Features";
            this.featuresToolStripMenuItem.Click += new System.EventHandler(this.featuresToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.versionToolStripMenuItem.Text = "About";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stt_main});
            this.statusStrip1.Location = new System.Drawing.Point(0, 703);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stt_main
            // 
            this.stt_main.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.stt_main.Name = "stt_main";
            this.stt_main.Size = new System.Drawing.Size(74, 21);
            this.stt_main.Text = "Welcome";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Config);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 674);
            this.tabControl1.TabIndex = 2;
            // 
            // tab_Config
            // 
            this.tab_Config.Controls.Add(this.groupBox2);
            this.tab_Config.Controls.Add(this.groupBox1);
            this.tab_Config.Controls.Add(this.list_Emulator);
            this.tab_Config.Location = new System.Drawing.Point(4, 29);
            this.tab_Config.Name = "tab_Config";
            this.tab_Config.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Config.Size = new System.Drawing.Size(1000, 641);
            this.tab_Config.TabIndex = 0;
            this.tab_Config.Text = "Config";
            this.tab_Config.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(585, 161);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 477);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LD Player Config";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_DefaultLDHeight);
            this.groupBox1.Controls.Add(this.txt_DefaultLDWidth);
            this.groupBox1.Controls.Add(this.btn_SaveGeneralConfig);
            this.groupBox1.Controls.Add(this.lbl_BrowseLDFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(585, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Config";
            // 
            // txt_DefaultLDHeight
            // 
            this.txt_DefaultLDHeight.Location = new System.Drawing.Point(222, 60);
            this.txt_DefaultLDHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txt_DefaultLDHeight.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.txt_DefaultLDHeight.Name = "txt_DefaultLDHeight";
            this.txt_DefaultLDHeight.Size = new System.Drawing.Size(63, 26);
            this.txt_DefaultLDHeight.TabIndex = 4;
            this.txt_DefaultLDHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DefaultLDHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // txt_DefaultLDWidth
            // 
            this.txt_DefaultLDWidth.Location = new System.Drawing.Point(153, 60);
            this.txt_DefaultLDWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txt_DefaultLDWidth.Minimum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.txt_DefaultLDWidth.Name = "txt_DefaultLDWidth";
            this.txt_DefaultLDWidth.Size = new System.Drawing.Size(63, 26);
            this.txt_DefaultLDWidth.TabIndex = 4;
            this.txt_DefaultLDWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DefaultLDWidth.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            // 
            // btn_SaveGeneralConfig
            // 
            this.btn_SaveGeneralConfig.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_SaveGeneralConfig.Location = new System.Drawing.Point(331, 124);
            this.btn_SaveGeneralConfig.Name = "btn_SaveGeneralConfig";
            this.btn_SaveGeneralConfig.Size = new System.Drawing.Size(75, 28);
            this.btn_SaveGeneralConfig.TabIndex = 3;
            this.btn_SaveGeneralConfig.Text = "Save";
            this.btn_SaveGeneralConfig.UseVisualStyleBackColor = false;
            this.btn_SaveGeneralConfig.Click += new System.EventHandler(this.btn_SaveGeneralConfig_Click);
            // 
            // lbl_BrowseLDFolder
            // 
            this.lbl_BrowseLDFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_BrowseLDFolder.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_BrowseLDFolder.Location = new System.Drawing.Point(153, 25);
            this.lbl_BrowseLDFolder.Name = "lbl_BrowseLDFolder";
            this.lbl_BrowseLDFolder.Size = new System.Drawing.Size(234, 22);
            this.lbl_BrowseLDFolder.TabIndex = 2;
            this.lbl_BrowseLDFolder.Text = "Browse Folder";
            this.lbl_BrowseLDFolder.Click += new System.EventHandler(this.lbl_BrowseLDFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Default Resolution";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "LD Folder";
            // 
            // list_Emulator
            // 
            this.list_Emulator.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.list_Emulator.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.list_Emulator.Dock = System.Windows.Forms.DockStyle.Left;
            this.list_Emulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Emulator.FullRowSelect = true;
            this.list_Emulator.HideSelection = false;
            this.list_Emulator.Location = new System.Drawing.Point(3, 3);
            this.list_Emulator.Name = "list_Emulator";
            this.list_Emulator.Size = new System.Drawing.Size(582, 635);
            this.list_Emulator.TabIndex = 0;
            this.list_Emulator.UseCompatibleStateImageBehavior = false;
            this.list_Emulator.View = System.Windows.Forms.View.Details;
            this.list_Emulator.SelectedIndexChanged += new System.EventHandler(this.list_Emulator_SelectedIndexChanged);
            this.list_Emulator.DoubleClick += new System.EventHandler(this.list_Emulator_DoubleClick);
            this.list_Emulator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_Emulator_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Idx";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 190;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 349;
            // 
            // listLDContextMenuStrip1
            // 
            this.listLDContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.rebootToolStripMenuItem1,
            this.closeToolStripMenuItem1,
            this.cloneToolStripMenuItem1,
            this.changeInfoToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.loadScriptToolStripMenuItem,
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem});
            this.listLDContextMenuStrip1.Name = "listLDContextMenuStrip1";
            this.listLDContextMenuStrip1.Size = new System.Drawing.Size(140, 202);
            // 
            // runSelectedToolStripMenuItem
            // 
            this.runSelectedToolStripMenuItem.Image = global::LDBot.Properties.Resources.power_on__1_;
            this.runSelectedToolStripMenuItem.Name = "runSelectedToolStripMenuItem";
            this.runSelectedToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.runSelectedToolStripMenuItem.Text = "Run Selected(s)";
            this.runSelectedToolStripMenuItem.Click += new System.EventHandler(this.runSelectedToolStripMenuItem_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Image = global::LDBot.Properties.Resources.page;
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.createNewToolStripMenuItem.Text = "Create new";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // quitAllToolStripMenuItem
            // 
            this.quitAllToolStripMenuItem.Image = global::LDBot.Properties.Resources.power_on;
            this.quitAllToolStripMenuItem.Name = "quitAllToolStripMenuItem";
            this.quitAllToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.quitAllToolStripMenuItem.Text = "Close All";
            this.quitAllToolStripMenuItem.Click += new System.EventHandler(this.quitAllToolStripMenuItem_Click);
            // 
            // loadScriptSelectedsToolStripMenuItem
            // 
            this.loadScriptSelectedsToolStripMenuItem.Image = global::LDBot.Properties.Resources.import;
            this.loadScriptSelectedsToolStripMenuItem.Name = "loadScriptSelectedsToolStripMenuItem";
            this.loadScriptSelectedsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.loadScriptSelectedsToolStripMenuItem.Text = "Load Script Selected(s)";
            this.loadScriptSelectedsToolStripMenuItem.Click += new System.EventHandler(this.loadScriptSelectedsToolStripMenuItem_Click);
            // 
            // startScriptSelectedsToolStripMenuItem
            // 
            this.startScriptSelectedsToolStripMenuItem.Image = global::LDBot.Properties.Resources.tick_mark;
            this.startScriptSelectedsToolStripMenuItem.Name = "startScriptSelectedsToolStripMenuItem";
            this.startScriptSelectedsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.startScriptSelectedsToolStripMenuItem.Text = "Start Script Selected(s)";
            this.startScriptSelectedsToolStripMenuItem.Click += new System.EventHandler(this.startScriptSelectedsToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Image = global::LDBot.Properties.Resources.power_on__1_;
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem1
            // 
            this.rebootToolStripMenuItem1.Image = global::LDBot.Properties.Resources.refresh;
            this.rebootToolStripMenuItem1.Name = "rebootToolStripMenuItem1";
            this.rebootToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.rebootToolStripMenuItem1.Text = "Reboot";
            this.rebootToolStripMenuItem1.Click += new System.EventHandler(this.rebootToolStripMenuItem1_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Image = global::LDBot.Properties.Resources.power_on;
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // cloneToolStripMenuItem1
            // 
            this.cloneToolStripMenuItem1.Image = global::LDBot.Properties.Resources.visualization;
            this.cloneToolStripMenuItem1.Name = "cloneToolStripMenuItem1";
            this.cloneToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.cloneToolStripMenuItem1.Text = "Clone";
            this.cloneToolStripMenuItem1.Click += new System.EventHandler(this.cloneToolStripMenuItem1_Click);
            // 
            // changeInfoToolStripMenuItem1
            // 
            this.changeInfoToolStripMenuItem1.Image = global::LDBot.Properties.Resources.smartphone__1_;
            this.changeInfoToolStripMenuItem1.Name = "changeInfoToolStripMenuItem1";
            this.changeInfoToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.changeInfoToolStripMenuItem1.Text = "Change Info";
            this.changeInfoToolStripMenuItem1.Click += new System.EventHandler(this.changeInfoToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::LDBot.Properties.Resources.delete;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // loadScriptToolStripMenuItem
            // 
            this.loadScriptToolStripMenuItem.Image = global::LDBot.Properties.Resources.import;
            this.loadScriptToolStripMenuItem.Name = "loadScriptToolStripMenuItem";
            this.loadScriptToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.loadScriptToolStripMenuItem.Text = "Load Script";
            this.loadScriptToolStripMenuItem.Click += new System.EventHandler(this.loadScriptToolStripMenuItem_Click);
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Image = global::LDBot.Properties.Resources.tick_mark;
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.startScriptToolStripMenuItem.Text = "Start Script";
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.startScriptToolStripMenuItem_Click);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Image = global::LDBot.Properties.Resources.stop;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.stopScriptToolStripMenuItem.Text = "Stop Script";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.stopScriptToolStripMenuItem_Click);
            // 
            // stopScriptSelectedsToolStripMenuItem
            // 
            this.stopScriptSelectedsToolStripMenuItem.Image = global::LDBot.Properties.Resources.stop;
            this.stopScriptSelectedsToolStripMenuItem.Name = "stopScriptSelectedsToolStripMenuItem";
            this.stopScriptSelectedsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.stopScriptSelectedsToolStripMenuItem.Text = "Stop Script Selected(s)";
            this.stopScriptSelectedsToolStripMenuItem.Click += new System.EventHandler(this.stopScriptSelectedsToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "LDBot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_Config.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DefaultLDHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DefaultLDWidth)).EndInit();
            this.listLDContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Config;
        private System.Windows.Forms.ListView list_Emulator;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripStatusLabel stt_main;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_BrowseLDFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_SaveGeneralConfig;
        private System.Windows.Forms.ToolStripMenuItem menu_LDEmulator;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runSelectedToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown txt_DefaultLDHeight;
        private System.Windows.Forms.NumericUpDown txt_DefaultLDWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listLDContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadScriptSelectedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startScriptSelectedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopScriptSelectedsToolStripMenuItem;
    }
}

