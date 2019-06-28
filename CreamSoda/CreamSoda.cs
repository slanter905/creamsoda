﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace CreamSoda
{
    public partial class CreamSoda : Form
    {
        WorkThread myWorker;

        private bool NoMove = false;
        private bool DevMode = false;
        
        string ManifestURL = "";

        public CreamSoda()
        {
            InitializeComponent();
        }

        private bool Setup() {
            try {
                if (Settings.SetupNeeded)
                {
                    MyToolkit.ActivityLog("Setting up CreamSoda");
                    string myPath = "";
                    bool PathValid = false;
                    FolderBrowserDialog FileBox;

                    do {
                        FileBox = new FolderBrowserDialog
                        {
                            Description = "Select a location where you would like to install CreamSoda; preferably under My Documents or Application Data. Do not use a folder under Program Files.",
                            SelectedPath = Application.StartupPath
                        };

                        if (FileBox.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) {
                            MessageBox.Show("You must select a valid install directory to continue.\nCreamSoda will now quit. Restart CreamSoda once you have a valid installation path.");
                            Application.Exit();
                            return false;
                        }

                        myPath = FileBox.SelectedPath;
                        PathValid = true;

                    } while (!PathValid);

                    Settings.GamePath = myPath;

                    MyToolkit.ActivityLog("CreamSoda installed at \"" + myPath + "\"");
                }

                SelfRelocate();
                return true;

            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Setup");
                return false;
            }
        }

        private void SelfRelocate() {
            if (NoMove) return;
            Preferences.SelfRelocate();
        }

        private void Skin()
        {
            BackColor = Settings.BGColor;
            label1.ForeColor = Settings.TextColor;
            lblStatus.ForeColor = Settings.TextColor;
            ListBox1.BackColor = Settings.ListColor;
            ListBox1.ForeColor = Settings.ListTextColor;
        }

        private void ScanParameters() {
            
            if(MyToolkit.AllArgs().Trim() != "") 
                MyToolkit.ActivityLog("Launched with following parameters: " + MyToolkit.AllArgs());

            for (int i = 0; i < MyToolkit.args.Length; i++)
            {
                // Check for parameters overriding the download of a new manifest                   
                if (MyToolkit.args[i].Trim() == "-o")
                {
                    WorkThread.DontDownloadManifest = true;
                }
                // Check for parameters overriding self patching                                    
                else if (MyToolkit.args[i].Trim() == "-noselfpatch" ||
                         MyToolkit.args[i].Trim() == "-noselfupdate" ||
                         MyToolkit.args[i].Trim() == "-nodisassemblejohnny5") // He's alive. Nice one ;)
                {
                    WorkThread.DontSelfUpdate = true;
                }
                // Check for parameters overriding self patching                                    
                else if (MyToolkit.args[i].Trim() == "-md5")
                {
                    NoMove = true;
                    WorkThread.DontSelfUpdate = true;
                    //WorkThread.GenerageChecksumToClipboard = true;

                    Fingerprint myFingerprint = new Fingerprint(Application.StartupPath, Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""));
                    Clipboard.SetText("md5=\"" + myFingerprint.Checksum + "\" size=\"" + myFingerprint.Size + "\"");
                }
                // Check for parameters disabling self relocate (this option also makes it not self patch) 
                else if (MyToolkit.args[i].Trim() == "-nomove")
                {
                    NoMove = true;
                    WorkThread.DontSelfUpdate = true;
                } 
                // Check for parameters disabling self relocate (this option also makes it not self patch) 
                else if (MyToolkit.args[i].Trim() == "-devmode" ||
                         MyToolkit.args[i].Trim() == "-dev")
                {
                    DevMode = true;
                }
                // Pick up manifest download override                                               
                else if (MyToolkit.args.Length > i + 1)
                {
                    if (MyToolkit.args[i].Trim() == "-m")
                    {
                        if (MyToolkit.args[i + 1].Trim() == "")
                        {
                            MessageBox.Show("No manifest specified in parameter -m, using default.");
                        }
                        else
                        {
                            ManifestURL = MyToolkit.args[i + 1];

                            // Get a list of currently registered manifests                                 //
                            List<string> Manifests = Settings.Manifests;

                            // Find out if this manifest is already in the list                             //
                            bool ManifestExists = false;
                            foreach (string Manifest in Manifests)
                            {
                                if (Manifest.Equals(ManifestURL, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    ManifestExists = true;
                                    break;
                                }
                            }

                            // If manifest is not in the list, add it                                       //
                            if (!ManifestExists) {
                                Manifests.Add(ManifestURL);
                                Settings.Manifests = Manifests;
                            }

                            // Make this the default manifest                                               //
                            Settings.LastManifest = ManifestURL;

                        }
                    }
                }
            }
        }

        private void ProcessKiller() {
            try
            {

                Process[] prs = Process.GetProcessesByName("CreamSoda");
                Process me = Process.GetCurrentProcess();
                int killcount = 0;
                int killfailcount = 0;
                foreach (Process pr in prs)
                {
                    if (pr.Id != me.Id)
                    {
                        MyToolkit.ActivityLog("Shutting down previous instance of patcher...");
                        killcount++;
                        try
                        {
                            pr.Kill();
                        } catch (Exception)
                        {
                            killfailcount++;
                        }
                    }
                }

                if (killcount > 0) Thread.Sleep(2000);
                if (killfailcount > 0) MessageBox.Show(null, "Found a running instance of CreamSoda but was not able to terminate it.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            } catch (Exception) { }
        }


        protected bool loaded = false;
        private void Form_Load(object sender, EventArgs e)
        {
            MyToolkit.ActivityLog("Loading application.");
            try
            {
                // Attempt to kill any other version of the patcher //
                // that may be running                              //
                ProcessKiller();


                this.Text += " " + Application.ProductVersion;
                Skin();

                ScanParameters();

                LoadManifestList();

                timer1.Enabled = Setup();
            }
            catch (Exception ex)
            {
                MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
            }

            loaded = true;

            MyToolkit.ActivityLog("Load application complete.");
        }


        public void LoadManifestList() {
            loaded = false;
            // Load the list of stored manifests                //
            List<string> Manifests = Settings.Manifests;

            if (Manifests.Count == 0) {
                Manifests.Add("http://wehavecake.net/manifest.xml");
                Settings.Manifests = Manifests;
            }
        
            cbManifest.DataSource = Manifests;
            ManifestURL = Manifests[0];

            // Attempt to re-select the last used manifest      //
            for (int i = 0; i < Manifests.Count; i++)
            {
                if (Manifests[i] == Settings.LastManifest)
                {
                    cbManifest.SelectedIndex = i;
                    ManifestURL = Settings.LastManifest;
                    break;
                }
            }
            loaded = true;
        }

        private void StartUp() {
            try
            {
                MyToolkit.ActivityLog("Started patching");
                string PathRoot = Settings.GamePath;
                string LocalManifest = PathRoot + @"CreamSoda.xml";

                btnPlay.Text = "Please wait...";
                btnPlay.Enabled = false;
                cbManifest.Enabled = false;

                myWorker = new WorkThread(ManifestURL)
                {
                    LocalManifest = LocalManifest,
                    PathRoot = PathRoot
                };
                myWorker.DownloadManifest();
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".StartUp");
            }
        }

        private void Finish() {
            try{
                MyToolkit.ActivityLog("Finished patching.");

                Progress.Value = 100;
                timer1.Enabled = false;

                if (myWorker.ErrorMessage != "")
                {
                    txtErrors.Text = myWorker.ErrorMessage;
                    webBrowser1.Visible = false;
                    pnlErrors.Visible = true;
                } else {
                    btnPlay.Enabled = true;
                    cbManifest.Enabled = true;
                    btnPlay.Text = "Play";
                }
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Finish");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (myWorker == null)
                {
                    StartUp();
                    return;
                }

                if ((myWorker.ForumURL != "") && (myWorker.ForumURL != (String)webBrowser1.Tag) && (myWorker.ForumURL != webBrowser1.Url.AbsoluteUri) && (!webBrowser1.IsBusy))
                {
                    MyToolkit.ActivityLog("Loading Web Browser URL to: \"" + myWorker.ForumURL + "\"");
                    webBrowser1.Tag = myWorker.ForumURL;
                    webBrowser1.Navigate(myWorker.ForumURL);
                }

                if (myWorker.Manifest != null)

                    
                    if (ListBox1.Items.Count <= 1)
                    {
                        IEnumerable<XElement> Profiles = myWorker.Manifest.Descendants("launch");
                        List<object> items = new List<object>();

                        foreach (XElement profile in Profiles)
                        {
                            items.Add(new LaunchProfile(profile.Value.ToString().Replace("My App: ", "").Trim(),
                                                         profile.GetAttributeValueOrDefault("exec"),
                                                         profile.GetAttributeValueOrDefault("website"),
                                                         profile.GetAttributeValueOrDefault("params")));
                        }

                        if (DevMode) {
                            Profiles = myWorker.Manifest.Descendants("devlaunch");
                            
                            foreach (XElement profile in Profiles)
                            {
                                items.Add(new LaunchProfile(profile.Value.ToString().Replace("My App: ", "").Trim(),
                                                             profile.GetAttributeValueOrDefault("exec"),
                                                             profile.GetAttributeValueOrDefault("website"),
                                                             profile.GetAttributeValueOrDefault("params")));
                            }
                        }

                        ListBox1.DisplayMember = "Text";
                        ListBox1.DataSource = items;
                        ListBox1.SelectedIndex = 0;
                    }

                Progress.Value = MyToolkit.MinMax(myWorker.CurProgress, 0, 100);
                lblStatus.Text = myWorker.Status + "... " + myWorker.CurFile;

                if (myWorker.Status == "Done") Finish();
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try {
                MyToolkit.ActivityLog("User clicked play with the following profile: " + ((LaunchProfile)ListBox1.SelectedItem).Text);

                var startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = Settings.GamePath,
                    FileName = ((LaunchProfile)ListBox1.SelectedItem).Exec,
                    Arguments = ((LaunchProfile)ListBox1.SelectedItem).Params
                };
                startInfo.Arguments += " " + Settings.GameParams;

                Process.Start(startInfo);
                if (Settings.QuitOnLaunch) Application.Exit();
                
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".btnPlay_Click");
            }
        }

        private void btnScreenshots_Click(object sender, EventArgs e)
        {
            try {
                MyToolkit.ActivityLog("User clicked to open screenshots directory");
                string screenshotDir = Path.Combine(Settings.GamePath, "screenshots");

                if (!Directory.Exists(screenshotDir)) {
                    Directory.CreateDirectory(screenshotDir);
                }
                System.Diagnostics.Process.Start("explorer.exe", screenshotDir);
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".btScreenshots_Click");
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyToolkit.ActivityLog("Application quitting");
            WorkThread.Kill = true;
            DirCopy.Kill = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyToolkit.ActivityLog("User clicked to open Options window");
            Preferences prefs = new Preferences();
            prefs.btnRevalidate.Enabled = (myWorker.Status == "Done");
            prefs.ShowDialog(this);
            Skin();

            LoadManifestList();

            if (prefs.ReValidate) {
                ReValidate();
            }
        }

        private void ReValidate() {
            try
            {
                pnlErrors.Visible = false;
                webBrowser1.Visible = true;

                MyToolkit.ActivityLog("Revalidation process started");
                ListBox1.DataSource = null;
                File.Delete(Path.Combine(Settings.GamePath, "CreamSodalog.xml"));
                timer1.Enabled = Setup();
                StartUp();
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
            }
        }

        private void cbManifest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded && Settings.LastManifest != cbManifest.SelectedItem.ToString())
            {
                MyToolkit.ActivityLog("Manifest changed to \"" + cbManifest.SelectedItem.ToString() + "\"");
                Settings.LastManifest = cbManifest.SelectedItem.ToString();
                ManifestURL = Settings.LastManifest;
                ReValidate();
            }
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(((LaunchProfile)this.ListBox1.SelectedItem).Website);
        }
    }
}
