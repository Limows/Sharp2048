using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharp2048
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Closing(object sender, CancelEventArgs e)
        {
            if (Parameters.IsSaveOptions)
            {
                if (SquareButton.Checked)
                {
                    Parameters.Pallete = Parameters.PalleteType.Square;
                }
                else
                {
                    Parameters.Pallete = Parameters.PalleteType.Rounded;
                }

                Parameters.FieldSize = (int)(FieldSizeUpDown.Value);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            if (Parameters.Pallete == Parameters.PalleteType.Square)
            {
                SquareButton.Checked = true;
            }
            else
            {
                RoundedButton.Checked = true;
            }

            FieldSizeUpDown.Value = Parameters.FieldSize;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Parameters.IsSaveOptions = true;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Parameters.IsSaveOptions = false;
            Close();
        }
    }
}
