using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AnubisClient
{
    
    public partial class ClientForm : Form
    {

        RobotInterface ROI;
        public ClientForm()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }


        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            
        }

       
        private void btn_ShutDownRobot_Click(object sender, EventArgs e)
        {
         
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void commandViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void set_gui_label_kinematics(string text)
        {
            gui_joint_angles_label.Text = text;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Kinect 1")
            {
                NetworkView view = new NetworkView();
                view.Show();
            }
        }

        
    }
}
