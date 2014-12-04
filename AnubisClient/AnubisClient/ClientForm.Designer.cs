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
            this.kinnectWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gui_joint_angles_label = new System.Windows.Forms.Label();
            this.gui_comm_message_label = new System.Windows.Forms.Label();
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
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            this.commandViewToolStripMenuItem.Name = "commandViewToolStripMenuItem";
            this.commandViewToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.commandViewToolStripMenuItem.Text = "Command View";
            this.commandViewToolStripMenuItem.Click += new System.EventHandler(this.commandViewToolStripMenuItem_Click);
            // 
            // kinnectWindowsToolStripMenuItem
            // 
            this.kinnectWindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kinect1ToolStripMenuItem,
            this.kinect2ToolStripMenuItem,
            this.kinect3ToolStripMenuItem,
            this.kinect4ToolStripMenuItem});
            this.kinnectWindowsToolStripMenuItem.Name = "kinnectWindowsToolStripMenuItem";
            this.kinnectWindowsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.kinnectWindowsToolStripMenuItem.Text = "Kinect Windows";
            // 
            // kinect1ToolStripMenuItem
            // 
            this.kinect1ToolStripMenuItem.Name = "kinect1ToolStripMenuItem";
            this.kinect1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kinect1ToolStripMenuItem.Text = "Kinect 1";
            // 
            // kinect2ToolStripMenuItem
            // 
            this.kinect2ToolStripMenuItem.Name = "kinect2ToolStripMenuItem";
            this.kinect2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kinect2ToolStripMenuItem.Text = "Kinect 2";
            // 
            // kinect3ToolStripMenuItem
            // 
            this.kinect3ToolStripMenuItem.Name = "kinect3ToolStripMenuItem";
            this.kinect3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kinect3ToolStripMenuItem.Text = "Kinect 3";
            // 
            // kinect4ToolStripMenuItem
            // 
            this.kinect4ToolStripMenuItem.Name = "kinect4ToolStripMenuItem";
            this.kinect4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kinect4ToolStripMenuItem.Text = "Kinect 4";
            // 
            // networkWindowToolStripMenuItem
            // 
            this.networkWindowToolStripMenuItem.Name = "networkWindowToolStripMenuItem";
            this.networkWindowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.networkWindowToolStripMenuItem.Text = "Network Window";
            // 
            // gui_joint_angles_label
            // 
            this.gui_joint_angles_label.AutoSize = true;
            this.gui_joint_angles_label.Location = new System.Drawing.Point(228, 240);
            this.gui_joint_angles_label.Name = "gui_joint_angles_label";
            this.gui_joint_angles_label.Size = new System.Drawing.Size(77, 13);
            this.gui_joint_angles_label.TabIndex = 2;
            this.gui_joint_angles_label.Text = "stuff goes here";
            // 
            // gui_comm_message_label
            // 
            this.gui_comm_message_label.AutoSize = true;
            this.gui_comm_message_label.Location = new System.Drawing.Point(228, 274);
            this.gui_comm_message_label.Name = "gui_comm_message_label";
            this.gui_comm_message_label.Size = new System.Drawing.Size(77, 13);
            this.gui_comm_message_label.TabIndex = 3;
            this.gui_comm_message_label.Text = "stuff goes here";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 524);
            this.Controls.Add(this.gui_comm_message_label);
            this.Controls.Add(this.gui_joint_angles_label);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
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
        private System.Windows.Forms.ToolStripMenuItem kinect1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkWindowToolStripMenuItem;
        private System.Windows.Forms.Label gui_joint_angles_label;
        private System.Windows.Forms.Label gui_comm_message_label;


    }
}