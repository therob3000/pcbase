namespace AnubisClient
{
    partial class CommandView
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
            this.btn_UpdateGrid = new System.Windows.Forms.Button();
            this.lbx_CommandList = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_UpdateGrid
            // 
            this.btn_UpdateGrid.Location = new System.Drawing.Point(13, 244);
            this.btn_UpdateGrid.Name = "btn_UpdateGrid";
            this.btn_UpdateGrid.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateGrid.TabIndex = 1;
            this.btn_UpdateGrid.Text = "Update Table";
            this.btn_UpdateGrid.UseVisualStyleBackColor = true;
            this.btn_UpdateGrid.Click += new System.EventHandler(this.btn_UpdateGrid_Click);
            // 
            // lbx_CommandList
            // 
            this.lbx_CommandList.FormattingEnabled = true;
            this.lbx_CommandList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.lbx_CommandList.Location = new System.Drawing.Point(13, 13);
            this.lbx_CommandList.Name = "lbx_CommandList";
            this.lbx_CommandList.Size = new System.Drawing.Size(242, 225);
            this.lbx_CommandList.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CommandView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 274);
            this.Controls.Add(this.lbx_CommandList);
            this.Controls.Add(this.btn_UpdateGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommandView";
            this.Text = "CommandView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_UpdateGrid;
        private System.Windows.Forms.ListBox lbx_CommandList;
        private System.Windows.Forms.Timer timer1;

    }
}