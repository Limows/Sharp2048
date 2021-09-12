using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Sharp2048
{
    public partial class DonatBox : Form
    {
        public DonatBox()
        {
            InitializeComponent();

            this.Text = String.Format("Donat");
            this.BackColor = Color.FromArgb(187, 173, 160);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}