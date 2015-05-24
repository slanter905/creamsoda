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
            lblInstallPath.Text = Settings.GamePath;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbManifests.Text != Settings.LastManifest)
            {
                Settings.LastManifest = lbManifests.Text;
                ReValidate = true;
            }
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
            
            List<string> Manifests = Settings.Manifests;
            lbManifests.DataSource = Manifests;

            // Attempt to re-select the last used manifest      //
            try {
                for (int i = 0; i < Manifests.Count; i++) {
                    if (Manifests[i] == Settings.LastManifest) {
                        lbManifests.SelectedIndex = i;
                    }
                }
            } catch (Exception ex) {}
        }

        private void btnRevalidate_Click(object sender, EventArgs e)
        {
            ReValidate = true;
            this.Close();
        }

        private void btnInstallPathBrowse_Click(object sender, EventArgs e)
        {
            string myPath = "";
            bool PathValid = false;
            FolderBrowserDialog FileBox;

            do
            {
                FileBox = new FolderBrowserDialog();

                FileBox.Description = "Select a location where you would like to install Tequila; preferably under My Documents or Application Data. Do not use a folder under Program Files.";
                FileBox.SelectedPath = Settings.GamePath;

                if (FileBox.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                myPath = FileBox.SelectedPath;
                PathValid = true;

            } while (!PathValid);

            Settings.GamePath = myPath;
        }

        private void btnAddManifest_Click(object sender, EventArgs e)
        {
            List<string> Manifests = (List<string>)lbManifests.DataSource;

            // Make sure this is not a duplicate manifest       //
            foreach (string manifest in Manifests) {
                if (manifest.Equals(txtNewManifest.Text.Trim(),StringComparison.CurrentCultureIgnoreCase)) {
                    txtNewManifest.Text = "";
                    return;
                }
            }

            // Not a dup? keep going                            //
            Manifests.Add(txtNewManifest.Text);
            Settings.Manifests = Manifests;
            lbManifests.DataSource = Settings.Manifests;
            txtNewManifest.Text = "";

            // Attempt to re-select the last used manifest      //
            try {
                for (int i = 0; i < Manifests.Count; i++) {
                    if (Manifests[i] == Settings.LastManifest) {
                        lbManifests.SelectedIndex = i;
                    }
                }
            } catch (Exception ex) { }
        }

        private void DeleteSelectedManifest()
        {
            List<string> Manifests = (List<string>)lbManifests.DataSource;
            int SelectedIndex = lbManifests.SelectedIndex;
            Manifests.RemoveAt(lbManifests.SelectedIndex);
            Settings.Manifests = Manifests;
            lbManifests.DataSource = Settings.Manifests;
            try {
                lbManifests.SelectedIndex = SelectedIndex - 1;
            } catch (Exception ex){
                lbManifests.SelectedIndex = 0;
            }
        }

        private void lbManifests_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedManifest();
            }
        }

    }
}
