using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tequila
{
    public partial class Preferences : Form
    {
        public bool ReValidate = false;

        public Preferences()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {

            colorDialog1.Color = Settings.BGColor;
            colorDialog1.ShowDialog(this);
            btnColor.BackColor = colorDialog1.Color;
            Settings.BGColor = colorDialog1.Color;

        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.TextColor;
            colorDialog1.ShowDialog(this);
            btnTextColor.BackColor = colorDialog1.Color;
            Settings.TextColor = colorDialog1.Color;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.QuitOnLaunch = ckbQuitOnLaunch.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.GameParams = txtParameters.Text.Trim();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            ckbQuitOnLaunch.Checked = Settings.QuitOnLaunch; 
            txtParameters.Text = Settings.GameParams;
            btnColor.BackColor = Settings.BGColor;
            btnTextColor.BackColor = Settings.TextColor;
        }

        private void btnRevalidate_Click(object sender, EventArgs e)
        {
            ReValidate = true;
            this.Close();
        }

    }
}
