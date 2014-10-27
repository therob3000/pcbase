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
    //Mwahahahah
    //This comment shall remain!
    public partial class ClientForm : Form
    {

        RobotInterface ROI;
        Form CommandViewForm;
        public ClientForm()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
            ROI = new RobotInterface();
            ROI.StartInterface();

            CommandViewForm = new CommandView();
            CommandViewForm.MdiParent = this;
            CommandViewForm.Show();

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

        
    }
}
