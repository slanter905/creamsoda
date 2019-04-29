using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreamSoda
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
            } catch (Exception) { }
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
                FileBox = new FolderBrowserDialog
                {
                    Description = "Select a location where you would like to install Cream Soda; preferably under My Documents or Application Data. Do not use a folder under Program Files.",
                    SelectedPath = Settings.GamePath
                };

                if (FileBox.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                myPath = FileBox.SelectedPath;
                PathValid = true;

            } while (!PathValid);

            SelfRelocate();

            Settings.GamePath = myPath;
        }

        private void btnDeleteManifest_Click(object sender, EventArgs e)
        {
            DeleteSelectedManifest();
            btnDelete.Enabled = false;
        }

        private void btnAddManifest_Click(object sender, EventArgs e)
        {
            List<string> Manifests = (List<string>)lbManifests.DataSource;

            // Make sure this is not a duplicate manifest       //

            for (int i = 0; i < Manifests.Count; i++)
            {
                if (Manifests[i].Equals(txtNewManifest.Text.Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    txtNewManifest.Text = "";
                    lbManifests.SelectedIndex = i;
                    return;
                }
            }

            // Not a dup? keep going                            //
            Manifests.Add(txtNewManifest.Text);
            Settings.Manifests = Manifests;
            lbManifests.DataSource = Settings.Manifests;
            Settings.LastManifest = txtNewManifest.Text.Trim();
            txtNewManifest.Text = "";

            // Attempt to re-select the last used manifest      //
            try {
                for (int i = 0; i < Manifests.Count; i++) {
                    if (Manifests[i] == Settings.LastManifest) {
                        lbManifests.SelectedIndex = i;
                    }
                }
            } catch (Exception) { }
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
            } catch (Exception)
            {
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

        public static void SelfRelocate()
        {
            try {

                if (Application.StartupPath == Settings.GamePath) return;
                if (!File.Exists(Application.ExecutablePath)) return;

                string ShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string ShortcutTarget = Path.Combine(Settings.GamePath, "CreamSoda.exe");

                MyToolkit.ActivityLog("Self Relocating CreamSoda to \"" + ShortcutTarget + "\"");

                if (!Directory.Exists(Settings.GamePath))
                    Directory.CreateDirectory(Settings.GamePath);

                try {
                    if (File.Exists(ShortcutTarget)) File.Delete(ShortcutTarget);
                    File.Move(Application.ExecutablePath, ShortcutTarget);
                } catch (Exception)
                {
                    File.Copy(Application.ExecutablePath, ShortcutTarget);
                    try { File.Move(Application.ExecutablePath, Path.Combine(Application.StartupPath, "deleteme.txt")); }
                    catch (Exception)
                    {
                        MyToolkit.ActivityLog("Failed to relocate CreamSoda to \"" + ShortcutTarget + "\"");  
                    }
                }

                try {
                    using (ShellLink shortcut = new ShellLink()) {
                        shortcut.Target = ShortcutTarget;
                        //shortcut.WorkingDirectory = Path.GetDirectoryName(ShortcutTarget);
                        shortcut.Description = "Drink up!";
                        shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                        shortcut.Save(Path.Combine(ShortcutPath, "CreamSoda.lnk"));
                    }
                } catch (Exception ex) {
                    MyToolkit.ActivityLog("Failed to create desktop shortcut \"" + ShortcutTarget + "\"");  
                    MessageBox.Show(ex.Message);
                }
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, "Preferences.SelfRelocate");
            }
        }

        private void lbManifests_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }
    }
}