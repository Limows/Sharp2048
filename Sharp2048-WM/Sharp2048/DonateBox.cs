using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Sharp2048
{
    public partial class DonateBox : Form
    {
        public DonateBox()
        {
            InitializeComponent();
        }

        private void OkMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}