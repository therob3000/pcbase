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
        Robot_Form RF;
        public ClientForm()
        {
            this.IsMdiContainer = true;
            RF = new Robot_Form();
            RF.MdiParent = this;
            InitializeComponent();
            
        }

        public void set_gui_label_kinematics(string text)
        {
            
        }

        private void networkWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RF.Show();
        }
        
    }
}
