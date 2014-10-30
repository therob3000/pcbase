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
        private static CommandView instance;

        private CommandView()
        {
            InitializeComponent();
            timer1.Start();
        }

        public static CommandView getInstance(Form parent)
        {
            if (instance == null)
            {
                instance = new CommandView();
                instance.MdiParent = parent;
            }
            return instance;
        }

        public static void clearInstance()
        {
            if (instance != null)
            {
                instance.Dispose();
            }
            instance = null;
        }

        private void btn_UpdateGrid_Click(object sender, EventArgs e)
        {
            lbx_CommandList.Items.Clear();
            string[] commandList = CommandBuilder.GetCurrentCommandArray();
            int i = 0;
            foreach (string channel in commandList)
            {
                lbx_CommandList.Items.Add("Channel " + i + ": " + channel);
                i++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbx_CommandList.Items.Clear();
            string[] commandList = CommandBuilder.GetCurrentCommandArray();
            int i = 0;
            foreach (string channel in commandList)
            {
                lbx_CommandList.Items.Add("Channel " + i + ": " + channel);
                i++;
            }
        }

        private void CommandView_Load(object sender, EventArgs e)
        {
            MdiParent.

        }

        private void CommandView_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommandView.clearInstance();

        }

    }
}
