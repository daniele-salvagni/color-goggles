namespace color_goggles
{
    partial class GogglesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GogglesForm));
            this.displayList = new System.Windows.Forms.ComboBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.ingameGroup = new System.Windows.Forms.GroupBox();
            this.ingameLbl = new System.Windows.Forms.Label();
            this.ingameBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.windowsGroup = new System.Windows.Forms.GroupBox();
            this.windowsLbl = new System.Windows.Forms.Label();
            this.windowsBar = new System.Windows.Forms.TrackBar();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.checkRemoveLimits = new System.Windows.Forms.CheckBox();
            this.checkIgnoreFocus = new System.Windows.Forms.CheckBox();
            this.checkAutostart = new System.Windows.Forms.CheckBox();
            this.checkEnable = new System.Windows.Forms.CheckBox();
            this.processList = new System.Windows.Forms.ListBox();
            this.processBox = new System.Windows.Forms.TextBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.githubLbl = new System.Windows.Forms.Label();
            this.twiterLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.remBtn = new System.Windows.Forms.Button();
            this.daemon = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateLbl = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.ingameGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingameBar)).BeginInit();
            this.windowsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBar)).BeginInit();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayList
            // 
            this.displayList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayList.Enabled = false;
            this.displayList.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.displayList.FormattingEnabled = true;
            this.displayList.Location = new System.Drawing.Point(10, 10);
            this.displayList.Name = "displayList";
            this.displayList.Size = new System.Drawing.Size(338, 21);
            this.displayList.TabIndex = 0;
            // 
            // testBtn
            // 
            this.testBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.testBtn.Location = new System.Drawing.Point(354, 9);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(64, 23);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // ingameGroup
            // 
            this.ingameGroup.Controls.Add(this.ingameLbl);
            this.ingameGroup.Controls.Add(this.ingameBar);
            this.ingameGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.ingameGroup.Location = new System.Drawing.Point(10, 37);
            this.ingameGroup.Name = "ingameGroup";
            this.ingameGroup.Size = new System.Drawing.Size(212, 64);
            this.ingameGroup.TabIndex = 2;
            this.ingameGroup.TabStop = false;
            this.ingameGroup.Text = "Ingame Saturation";
            // 
            // ingameLbl
            // 
            this.ingameLbl.Location = new System.Drawing.Point(168, 24);
            this.ingameLbl.Name = "ingameLbl";
            this.ingameLbl.Size = new System.Drawing.Size(35, 17);
            this.ingameLbl.TabIndex = 5;
            this.ingameLbl.Text = "100";
            this.ingameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ingameBar
            // 
            this.ingameBar.AutoSize = false;
            this.ingameBar.LargeChange = 1;
            this.ingameBar.Location = new System.Drawing.Point(9, 24);
            this.ingameBar.Maximum = 100;
            this.ingameBar.Minimum = -100;
            this.ingameBar.Name = "ingameBar";
            this.ingameBar.Size = new System.Drawing.Size(159, 24);
            this.ingameBar.TabIndex = 3;
            this.ingameBar.TickFrequency = 10;
            this.ingameBar.Value = 100;
            this.ingameBar.ValueChanged += new System.EventHandler(this.ingameBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Version: 1.0.1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // windowsGroup
            // 
            this.windowsGroup.Controls.Add(this.windowsLbl);
            this.windowsGroup.Controls.Add(this.windowsBar);
            this.windowsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.windowsGroup.Location = new System.Drawing.Point(10, 107);
            this.windowsGroup.Name = "windowsGroup";
            this.windowsGroup.Size = new System.Drawing.Size(212, 64);
            this.windowsGroup.TabIndex = 6;
            this.windowsGroup.TabStop = false;
            this.windowsGroup.Text = "Windows Saturation";
            // 
            // windowsLbl
            // 
            this.windowsLbl.Location = new System.Drawing.Point(168, 24);
            this.windowsLbl.Name = "windowsLbl";
            this.windowsLbl.Size = new System.Drawing.Size(35, 17);
            this.windowsLbl.TabIndex = 5;
            this.windowsLbl.Text = "0";
            this.windowsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windowsBar
            // 
            this.windowsBar.AutoSize = false;
            this.windowsBar.LargeChange = 1;
            this.windowsBar.Location = new System.Drawing.Point(9, 24);
            this.windowsBar.Maximum = 100;
            this.windowsBar.Minimum = -100;
            this.windowsBar.Name = "windowsBar";
            this.windowsBar.Size = new System.Drawing.Size(159, 24);
            this.windowsBar.TabIndex = 3;
            this.windowsBar.TickFrequency = 10;
            this.windowsBar.ValueChanged += new System.EventHandler(this.windowsBar_ValueChanged);
            // 
            // settingsBox
            // 
            this.settingsBox.Controls.Add(this.checkRemoveLimits);
            this.settingsBox.Controls.Add(this.checkIgnoreFocus);
            this.settingsBox.Controls.Add(this.checkAutostart);
            this.settingsBox.Controls.Add(this.checkEnable);
            this.settingsBox.Location = new System.Drawing.Point(230, 37);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(188, 134);
            this.settingsBox.TabIndex = 7;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // checkRemoveLimits
            // 
            this.checkRemoveLimits.AutoSize = true;
            this.checkRemoveLimits.ForeColor = System.Drawing.Color.SeaGreen;
            this.checkRemoveLimits.Location = new System.Drawing.Point(8, 100);
            this.checkRemoveLimits.Name = "checkRemoveLimits";
            this.checkRemoveLimits.Size = new System.Drawing.Size(107, 19);
            this.checkRemoveLimits.TabIndex = 3;
            this.checkRemoveLimits.Text = "Remove limits";
            this.checkRemoveLimits.UseVisualStyleBackColor = true;
            this.checkRemoveLimits.CheckedChanged += new System.EventHandler(this.checkRemoveLimits_CheckedChanged);
            // 
            // checkIgnoreFocus
            // 
            this.checkIgnoreFocus.AutoSize = true;
            this.checkIgnoreFocus.Location = new System.Drawing.Point(8, 75);
            this.checkIgnoreFocus.Name = "checkIgnoreFocus";
            this.checkIgnoreFocus.Size = new System.Drawing.Size(117, 19);
            this.checkIgnoreFocus.TabIndex = 2;
            this.checkIgnoreFocus.Text = "Ignore ALT+TAB";
            this.checkIgnoreFocus.UseVisualStyleBackColor = true;
            this.checkIgnoreFocus.CheckedChanged += new System.EventHandler(this.checkIgnoreFocus_CheckedChanged);
            // 
            // checkAutostart
            // 
            this.checkAutostart.AutoSize = true;
            this.checkAutostart.Checked = true;
            this.checkAutostart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutostart.Location = new System.Drawing.Point(8, 50);
            this.checkAutostart.Name = "checkAutostart";
            this.checkAutostart.Size = new System.Drawing.Size(154, 19);
            this.checkAutostart.TabIndex = 1;
            this.checkAutostart.Text = "Autostart with Windows";
            this.checkAutostart.UseVisualStyleBackColor = true;
            this.checkAutostart.CheckedChanged += new System.EventHandler(this.checkAutostart_CheckedChanged);
            // 
            // checkEnable
            // 
            this.checkEnable.AutoSize = true;
            this.checkEnable.Checked = true;
            this.checkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnable.Location = new System.Drawing.Point(8, 25);
            this.checkEnable.Name = "checkEnable";
            this.checkEnable.Size = new System.Drawing.Size(150, 19);
            this.checkEnable.TabIndex = 0;
            this.checkEnable.Text = "Enable Color-Goggles";
            this.checkEnable.UseVisualStyleBackColor = true;
            this.checkEnable.CheckedChanged += new System.EventHandler(this.checkEnable_CheckedChanged);
            // 
            // processList
            // 
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(10, 177);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(212, 69);
            this.processList.TabIndex = 8;
            // 
            // processBox
            // 
            this.processBox.Location = new System.Drawing.Point(10, 254);
            this.processBox.Name = "processBox";
            this.processBox.Size = new System.Drawing.Size(122, 20);
            this.processBox.TabIndex = 9;
            this.processBox.Text = "process.exe";
            // 
            // logoBox
            // 
            this.logoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoBox.Image = global::color_goggles.Properties.Resources.logo;
            this.logoBox.Location = new System.Drawing.Point(342, 193);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(66, 39);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoBox.TabIndex = 10;
            this.logoBox.TabStop = false;
            this.logoBox.Click += new System.EventHandler(this.logoBox_Click);
            // 
            // githubLbl
            // 
            this.githubLbl.AutoSize = true;
            this.githubLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.githubLbl.ForeColor = System.Drawing.Color.SeaGreen;
            this.githubLbl.Location = new System.Drawing.Point(235, 186);
            this.githubLbl.Name = "githubLbl";
            this.githubLbl.Size = new System.Drawing.Size(100, 15);
            this.githubLbl.TabIndex = 11;
            this.githubLbl.Text = "Star on GitHub ★";
            this.githubLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.githubLbl.Click += new System.EventHandler(this.githubLbl_Click);
            // 
            // twiterLbl
            // 
            this.twiterLbl.AutoSize = true;
            this.twiterLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twiterLbl.ForeColor = System.Drawing.Color.Gray;
            this.twiterLbl.Location = new System.Drawing.Point(235, 218);
            this.twiterLbl.Name = "twiterLbl";
            this.twiterLbl.Size = new System.Drawing.Size(47, 15);
            this.twiterLbl.TabIndex = 12;
            this.twiterLbl.Text = "@sdlnv";
            this.twiterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.twiterLbl.Click += new System.EventHandler(this.twiterLbl_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.addBtn.Location = new System.Drawing.Point(139, 253);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(39, 22);
            this.addBtn.TabIndex = 13;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // remBtn
            // 
            this.remBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.remBtn.Location = new System.Drawing.Point(183, 253);
            this.remBtn.Name = "remBtn";
            this.remBtn.Size = new System.Drawing.Size(39, 22);
            this.remBtn.TabIndex = 14;
            this.remBtn.Text = "⨯";
            this.remBtn.UseVisualStyleBackColor = true;
            this.remBtn.Click += new System.EventHandler(this.remBtn_Click);
            // 
            // daemon
            // 
            this.daemon.Enabled = true;
            this.daemon.Interval = 2500;
            this.daemon.Tick += new System.EventHandler(this.daemon_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Color-Goggles v1.0.1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableToolStripMenuItem,
            this.toolStripSeparator1,
            this.showToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(129, 106);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // updateLbl
            // 
            this.updateLbl.BackColor = System.Drawing.Color.SeaGreen;
            this.updateLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateLbl.ForeColor = System.Drawing.Color.White;
            this.updateLbl.Location = new System.Drawing.Point(230, 254);
            this.updateLbl.Name = "updateLbl";
            this.updateLbl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.updateLbl.Size = new System.Drawing.Size(188, 20);
            this.updateLbl.TabIndex = 16;
            this.updateLbl.Text = "Update Available!";
            this.updateLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.updateLbl.Click += new System.EventHandler(this.updateLbl_Click);
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Interval = 5000;
            // 
            // GogglesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(428, 285);
            this.Controls.Add(this.updateLbl);
            this.Controls.Add(this.remBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.twiterLbl);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.githubLbl);
            this.Controls.Add(this.processBox);
            this.Controls.Add(this.processList);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.windowsGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingameGroup);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.displayList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(446, 332);
            this.MinimumSize = new System.Drawing.Size(446, 332);
            this.Name = "GogglesForm";
            this.Text = " Color-Goggles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GogglesForm_FormClosing);
            this.Load += new System.EventHandler(this.GogglesForm_Load);
            this.Shown += new System.EventHandler(this.GogglesForm_Shown);
            this.ingameGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ingameBar)).EndInit();
            this.windowsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowsBar)).EndInit();
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox displayList;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.GroupBox ingameGroup;
        private System.Windows.Forms.Label ingameLbl;
        private System.Windows.Forms.TrackBar ingameBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox windowsGroup;
        private System.Windows.Forms.Label windowsLbl;
        private System.Windows.Forms.TrackBar windowsBar;
        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.ListBox processList;
        private System.Windows.Forms.TextBox processBox;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label githubLbl;
        private System.Windows.Forms.Label twiterLbl;
        private System.Windows.Forms.CheckBox checkIgnoreFocus;
        private System.Windows.Forms.CheckBox checkAutostart;
        private System.Windows.Forms.CheckBox checkEnable;
        private System.Windows.Forms.CheckBox checkRemoveLimits;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button remBtn;
        private System.Windows.Forms.Timer daemon;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label updateLbl;
        private System.Windows.Forms.Timer update;
    }
}

