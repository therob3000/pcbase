using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnubisClient
{
    public partial class CommandView : Form
    {
        public CommandView()
        {
            InitializeComponent();
        }

        private void btn_UpdateGrid_Click(object sender, EventArgs e)
        {
            string[] commandList = CommandBuilder.GetCurrentCommandArray();
            int i = 0;
            foreach (string channel in commandList)
            {
                lbx_CommandList.Items.Add("Channel 1 : " + channel);
                i++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] commandList = CommandBuilder.GetCurrentCommandArray();
            int i = 0;
            foreach (string channel in commandList)
            {
                lbx_CommandList.Items.Add("Channel 1 : " + channel);
                i++;
            }
        }

    }
}
