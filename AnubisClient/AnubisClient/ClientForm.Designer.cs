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
            this.tb_LHZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_HCZ = new System.Windows.Forms.TextBox();
            this.tb_RHZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_LHY = new System.Windows.Forms.TextBox();
            this.tb_HCY = new System.Windows.Forms.TextBox();
            this.tb_RHY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_DriveLeft = new System.Windows.Forms.Label();
            this.lbl_DriveMode = new System.Windows.Forms.Label();
            this.lbl_DriveRight = new System.Windows.Forms.Label();
            this.NetCommWorker = new System.ComponentModel.BackgroundWorker();
            this.ss_statusBar = new System.Windows.Forms.StatusStrip();
            this.ts_StatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_ShutDownRobot = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ss_statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_LHZ
            // 
            this.tb_LHZ.Location = new System.Drawing.Point(38, 47);
            this.tb_LHZ.Name = "tb_LHZ";
            this.tb_LHZ.Size = new System.Drawing.Size(100, 20);
            this.tb_LHZ.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Left Hand Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hip Center Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Right Hand Z";
            // 
            // tb_HCZ
            // 
            this.tb_HCZ.Location = new System.Drawing.Point(144, 47);
            this.tb_HCZ.Name = "tb_HCZ";
            this.tb_HCZ.Size = new System.Drawing.Size(100, 20);
            this.tb_HCZ.TabIndex = 0;
            // 
            // tb_RHZ
            // 
            this.tb_RHZ.Location = new System.Drawing.Point(250, 47);
            this.tb_RHZ.Name = "tb_RHZ";
            this.tb_RHZ.Size = new System.Drawing.Size(100, 20);
            this.tb_RHZ.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Left Hand Y";
            // 
            // tb_LHY
            // 
            this.tb_LHY.Location = new System.Drawing.Point(38, 102);
            this.tb_LHY.Name = "tb_LHY";
            this.tb_LHY.Size = new System.Drawing.Size(100, 20);
            this.tb_LHY.TabIndex = 0;
            // 
            // tb_HCY
            // 
            this.tb_HCY.Location = new System.Drawing.Point(144, 102);
            this.tb_HCY.Name = "tb_HCY";
            this.tb_HCY.Size = new System.Drawing.Size(100, 20);
            this.tb_HCY.TabIndex = 0;
            // 
            // tb_RHY
            // 
            this.tb_RHY.Location = new System.Drawing.Point(250, 102);
            this.tb_RHY.Name = "tb_RHY";
            this.tb_RHY.Size = new System.Drawing.Size(100, 20);
            this.tb_RHY.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hip Center Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Right Hand Y";
            // 
            // lbl_DriveLeft
            // 
            this.lbl_DriveLeft.AutoSize = true;
            this.lbl_DriveLeft.Location = new System.Drawing.Point(103, 140);
            this.lbl_DriveLeft.Name = "lbl_DriveLeft";
            this.lbl_DriveLeft.Size = new System.Drawing.Size(35, 13);
            this.lbl_DriveLeft.TabIndex = 2;
            this.lbl_DriveLeft.Text = "label7";
            // 
            // lbl_DriveMode
            // 
            this.lbl_DriveMode.AutoSize = true;
            this.lbl_DriveMode.Location = new System.Drawing.Point(164, 140);
            this.lbl_DriveMode.Name = "lbl_DriveMode";
            this.lbl_DriveMode.Size = new System.Drawing.Size(35, 13);
            this.lbl_DriveMode.TabIndex = 2;
            this.lbl_DriveMode.Text = "label7";
            // 
            // lbl_DriveRight
            // 
            this.lbl_DriveRight.AutoSize = true;
            this.lbl_DriveRight.Location = new System.Drawing.Point(247, 140);
            this.lbl_DriveRight.Name = "lbl_DriveRight";
            this.lbl_DriveRight.Size = new System.Drawing.Size(35, 13);
            this.lbl_DriveRight.TabIndex = 2;
            this.lbl_DriveRight.Text = "label7";
            // 
            // ss_statusBar
            // 
            this.ss_statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_StatusStrip});
            this.ss_statusBar.Location = new System.Drawing.Point(0, 240);
            this.ss_statusBar.Name = "ss_statusBar";
            this.ss_statusBar.Size = new System.Drawing.Size(482, 22);
            this.ss_statusBar.TabIndex = 3;
            this.ss_statusBar.Text = "ss_StatusBar";
            // 
            // ts_StatusStrip
            // 
            this.ts_StatusStrip.Name = "ts_StatusStrip";
            this.ts_StatusStrip.Size = new System.Drawing.Size(77, 17);
            this.ts_StatusStrip.Text = "ts_StatusStrip";
            // 
            // btn_ShutDownRobot
            // 
            this.btn_ShutDownRobot.Location = new System.Drawing.Point(323, 214);
            this.btn_ShutDownRobot.Name = "btn_ShutDownRobot";
            this.btn_ShutDownRobot.Size = new System.Drawing.Size(147, 23);
            this.btn_ShutDownRobot.TabIndex = 4;
            this.btn_ShutDownRobot.Text = "Shutdown Network Link";
            this.btn_ShutDownRobot.UseVisualStyleBackColor = true;
            this.btn_ShutDownRobot.Click += new System.EventHandler(this.btn_ShutDownRobot_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(458, 20);
            this.textBox1.TabIndex = 5;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_ShutDownRobot);
            this.Controls.Add(this.ss_statusBar);
            this.Controls.Add(this.lbl_DriveRight);
            this.Controls.Add(this.lbl_DriveMode);
            this.Controls.Add(this.lbl_DriveLeft);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_RHY);
            this.Controls.Add(this.tb_RHZ);
            this.Controls.Add(this.tb_HCY);
            this.Controls.Add(this.tb_HCZ);
            this.Controls.Add(this.tb_LHY);
            this.Controls.Add(this.tb_LHZ);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ss_statusBar.ResumeLayout(false);
            this.ss_statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_LHZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_HCZ;
        private System.Windows.Forms.TextBox tb_RHZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_LHY;
        private System.Windows.Forms.TextBox tb_HCY;
        private System.Windows.Forms.TextBox tb_RHY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_DriveLeft;
        private System.Windows.Forms.Label lbl_DriveMode;
        private System.Windows.Forms.Label lbl_DriveRight;
        private System.ComponentModel.BackgroundWorker NetCommWorker;
        private System.Windows.Forms.StatusStrip ss_statusBar;
        private System.Windows.Forms.ToolStripStatusLabel ts_StatusStrip;
        private System.Windows.Forms.Button btn_ShutDownRobot;
        private System.Windows.Forms.TextBox textBox1;


    }
}