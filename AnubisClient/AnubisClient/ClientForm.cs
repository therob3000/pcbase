﻿using System;
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

        public void set_gui_label_kinematics(string text)
        {
            
        }
        
    }
}
