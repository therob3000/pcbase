namespace AnubisClient
{
    partial class ClientForm
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
            this.NetCommWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeRobotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.networkSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinnectWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect2ToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.kinect3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.kinect4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewWindowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewWindowsToolStripMenuItem
            // 
            this.viewWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandViewToolStripMenuItem,
            this.kinnectWindowsToolStripMenuItem,
            this.networkWindowToolStripMenuItem});
            this.viewWindowsToolStripMenuItem.Name = "viewWindowsToolStripMenuItem";
            this.viewWindowsToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.viewWindowsToolStripMenuItem.Text = "View Windows";
            // 
            // commandViewToolStripMenuItem
            // 
            this.commandViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeRobotsToolStripMenuItem,
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.networkSettingsToolStripMenuItem});
            this.commandViewToolStripMenuItem.Name = "commandViewToolStripMenuItem";
            this.commandViewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.commandViewToolStripMenuItem.Text = "Network";
            // 
            // activeRobotsToolStripMenuItem
            // 
            this.activeRobotsToolStripMenuItem.Enabled = false;
            this.activeRobotsToolStripMenuItem.Name = "activeRobotsToolStripMenuItem";
            this.activeRobotsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.activeRobotsToolStripMenuItem.Text = "Active Robots";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // networkSettingsToolStripMenuItem
            // 
            this.networkSettingsToolStripMenuItem.Name = "networkSettingsToolStripMenuItem";
            this.networkSettingsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.networkSettingsToolStripMenuItem.Text = "Network Details";
            // 
            // kinnectWindowsToolStripMenuItem
            // 
            this.kinnectWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kinect1ToolStripMenuItem,
            this.kinect2ToolStripMenuItem,
            this.kinect3ToolStripMenuItem,
            this.kinect4ToolStripMenuItem,
            this.leapToolStripMenuItem,
            this.hardwareDetailsToolStripMenuItem});
            this.kinnectWindowsToolStripMenuItem.Name = "kinnectWindowsToolStripMenuItem";
            this.kinnectWindowsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kinnectWindowsToolStripMenuItem.Text = "Hardware";
            // 
            // kinect1ToolStripMenuItem
            // 
            this.kinect1ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.kinect1ToolStripMenuItem.Enabled = false;
            this.kinect1ToolStripMenuItem.Name = "kinect1ToolStripMenuItem";
            this.kinect1ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.kinect1ToolStripMenuItem.Text = "Active Kinects";
            // 
            // kinect2ToolStripMenuItem
            // 
            this.kinect2ToolStripMenuItem.Items.AddRange(new object[] {
            "Kinect 1",
            "Kinect 2",
            "Kinect 3",
            "Kinect 4"});
            this.kinect2ToolStripMenuItem.Name = "kinect2ToolStripMenuItem";
            this.kinect2ToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.kinect2ToolStripMenuItem.Text = "Kinect 2";
            // 
            // kinect3ToolStripMenuItem
            // 
            this.kinect3ToolStripMenuItem.Name = "kinect3ToolStripMenuItem";
            this.kinect3ToolStripMenuItem.Size = new System.Drawing.Size(209, 6);
            // 
            // kinect4ToolStripMenuItem
            // 
            this.kinect4ToolStripMenuItem.Name = "kinect4ToolStripMenuItem";
            this.kinect4ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.kinect4ToolStripMenuItem.Text = "Oculus";
            // 
            // leapToolStripMenuItem
            // 
            this.leapToolStripMenuItem.Name = "leapToolStripMenuItem";
            this.leapToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.leapToolStripMenuItem.Text = "Leap";
            // 
            // hardwareDetailsToolStripMenuItem
            // 
            this.hardwareDetailsToolStripMenuItem.Name = "hardwareDetailsToolStripMenuItem";
            this.hardwareDetailsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.hardwareDetailsToolStripMenuItem.Text = "Hardware Details";
            // 
            // networkWindowToolStripMenuItem
            // 
            this.networkWindowToolStripMenuItem.Name = "networkWindowToolStripMenuItem";
            this.networkWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.networkWindowToolStripMenuItem.Text = "Options";
            this.networkWindowToolStripMenuItem.Click += new System.EventHandler(this.networkWindowToolStripMenuItem_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 524);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker NetCommWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinnectWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox kinect2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator kinect3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeRobotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem networkSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareDetailsToolStripMenuItem;


    }
}