using System;
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

namespace Tequila
{
    public partial class Tequila : Form
    {
        WorkThread myWorker;
        DirCopy myCopyObj;
        Thread myCopyDirThread;

        private bool NoMove = false;
        private bool DevMode = false;
        
        string ManifestURL = "http://dl.dropboxusercontent.com/u/37952257/Tequila/titanicon.xml";

        public Tequila()
        {
            InitializeComponent();
        }

        private bool Setup() {
            try {
                if (Settings.SetupNeeded)
                {
                    string myPath = "";
                    bool PathValid = false;
                    FolderBrowserDialog FileBox;

                    do {
                        FileBox = new FolderBrowserDialog();
                    
                        FileBox.Description = "Select the game directory";
                        FileBox.SelectedPath = @"C:\Program Files (x86)\CohBeta";

                        if (FileBox.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) {
                            MessageBox.Show("You must select a valid install directory to continue. \nLauncher will now quit. Relaunch the laucher once you have a valid installation path.");
                            Application.Exit();
                            return false;
                        }

                        myPath = FileBox.SelectedPath; // FileName.Substring(0, FileBox.FileName.LastIndexOf("\\") + 1);

                        if (File.Exists(Path.Combine(myPath, "icon.exe")))
                        {
                            PathValid = true;
                        } else {
                            PathValid = false;
                            MessageBox.Show("The selected directory does not contain a full game installation.\r\nPlease make sure you select a directory that is not missing any files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } while (!PathValid);

                    if (!MyToolkit.InstallDirSafe(myPath)) {
                        string warning = "The game files will be copied to AppData\\TitanIcon; click OK to continue, Cancel to relocate the folder yourself and relaunch Tequila";
                        if (MessageBox.Show(warning, "test", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) {
                            Application.Exit();
                            return false;
                        }

                        string DestPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        DestPath = Path.Combine(DestPath, "TitanIcon");

                        myCopyObj = new DirCopy(myPath, DestPath);
                        myPath = DestPath;
                        myCopyDirThread = new Thread(new ThreadStart(myCopyObj.DirectoryCopy));
                        myCopyDirThread.Start();
                    }

                    Settings.GamePath = myPath;
                }

                SelfRelocate();
                ConsolidateVirtualStore();


                Settings.MainRepo = ManifestURL;

                return true;

            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Setup");
                return false;
            }

        }

        private void SelfRelocate() {
            if (NoMove) return;
            try {
                if (Application.StartupPath == Settings.GamePath) return;
                if (!File.Exists(Application.ExecutablePath)) return;

                string ShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string ShortcutTarget = Path.Combine(Settings.GamePath, "Tequila.exe");

                if (!Directory.Exists(Settings.GamePath))
                    Directory.CreateDirectory(Settings.GamePath);
            
                try {
                    if (File.Exists(ShortcutTarget)) File.Delete(ShortcutTarget);
                    File.Move(Application.ExecutablePath, ShortcutTarget);
                } catch (Exception ex) {
                    File.Copy(Application.ExecutablePath, ShortcutTarget);
                    try { File.Move(Application.ExecutablePath, Path.Combine(Application.StartupPath, "deleteme.txt")); } 
                    catch (Exception ex2) { }
                }

                try {
                    using (ShellLink shortcut = new ShellLink()) {
                        shortcut.Target = ShortcutTarget;
                        //shortcut.WorkingDirectory = Path.GetDirectoryName(ShortcutTarget);
                        shortcut.Description = "Drink up!";
                        shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                        shortcut.Save(Path.Combine(ShortcutPath, "Tequila.lnk"));
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".SelfRelocate");
            }
        }

        private void ConsolidateVirtualStore() {
            try {
                if (!Directory.Exists(Settings.GamePath))
                    Directory.CreateDirectory(Settings.GamePath);
            
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                if (Settings.GamePath != Path.Combine(localAppData, "TitanIcon")) return;
            
                string pathCoH = Path.Combine(localAppData, "VirtualStore\\Program Files (x86)\\TitanIcon");
                string pathCoHBeta = Path.Combine(localAppData, "VirtualStore\\Program Files (x86)\\TitanIcon");

                if (Directory.Exists(pathCoH)) {
                    DirCopy myCopy = new DirCopy(pathCoH, Settings.GamePath);
                    myCopy.DirectoryCopyNoReplace();
                }

                if (Directory.Exists(pathCoHBeta))
                {
                    DirCopy myCopy = new DirCopy(pathCoHBeta, Settings.GamePath);
                    myCopy.DirectoryCopyNoReplace(); 
                }

            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
            }
        }

        private void Skin()
        {
            BackColor = Settings.BGColor;
            label1.ForeColor = Settings.TextColor;
            lblStatus.ForeColor = Settings.TextColor;
            listBox1.BackColor = Settings.BGColor;
            listBox1.ForeColor = Settings.TextColor;
        }

        private void ScanParameters() {
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
                         MyToolkit.args[i].Trim() == "-nodisassemblejohnny5")
                {
                    WorkThread.DontSelfUpdate = true;
                }
                // Check for parameters overriding self patching                                    
                else if (MyToolkit.args[i].Trim() == "-md5")
                {
                    WorkThread.GenerageChecksumToClipboard = true;
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
                            ManifestURL = MyToolkit.args[1];
                        }
                    }
                }
            }
        }

        private void ProcessKiller() {
            try
            {

                Process[] prs = Process.GetProcessesByName("tequila");
                Process me = Process.GetCurrentProcess();
                int killcount = 0;
                int killfailcount = 0;
                foreach (Process pr in prs)
                {
                    if (pr.Id != me.Id)
                    {
                        killcount++;
                        try
                        {
                            pr.Kill();
                        } catch (Exception ex) {
                            killfailcount++;
                        }
                    }
                }

                if (killcount > 0) Thread.Sleep(2000);
                if (killfailcount > 0) MessageBox.Show(null, "Found a running instance of Tequila but was not able to terminate it.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            } catch (Exception ex) { }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessKiller();
                
                this.Text += " " + Application.ProductVersion;
                Skin();

                ScanParameters();

                timer1.Enabled = Setup();
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
            }
        }

        private void StartUp() {
            try
            {
                string PathRoot = Settings.GamePath;
                string LocalManifest = PathRoot + @"rspatcher.xml";

                btnPlay.Text = "...";
                btnPlay.Enabled = false;

                myWorker = new WorkThread(ManifestURL);
                myWorker.LocalManifest = LocalManifest;
                myWorker.PathRoot = PathRoot;
                myWorker.DownloadManifest();
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".StartUp");
            }
        }

        private void Finish() {
            try{
                Progress.Value = 100;
                timer1.Enabled = false;

                if (myWorker.ErrorMessage != "")
                {
                    txtErrors.Text = myWorker.ErrorMessage;
                    webBrowser1.Visible = false;
                    pnlErrors.Visible = true;
                } else {
                    btnPlay.Enabled = true;
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
                if (myCopyObj != null)
                {
                    if (myCopyObj.Active)
                    {
                        Progress.Value = myCopyObj.Progress;
                        return;
                    }
                }

                if (myWorker == null)
                {
                    StartUp();
                    return;
                }

                if (myWorker.Manifest != null)

                    if (listBox1.Items.Count <= 1)
                    {
                        IEnumerable<XElement> Profiles = myWorker.Manifest.Descendants("launch");
                        List<object> items = new List<object>();

                        foreach (XElement profile in Profiles)
                        {
                            items.Add(new LaunchProfile(profile.Value.ToString().Replace("My App: ", "").Trim(),
                                                         profile.Attribute("exec").Value,
                                                         profile.Attribute("params").Value));
                        }

                        if (DevMode) {
                            Profiles = myWorker.Manifest.Descendants("devlaunch");
                            
                            foreach (XElement profile in Profiles)
                            {
                                items.Add(new LaunchProfile(profile.Value.ToString().Replace("My App: ", "").Trim(),
                                                             profile.Attribute("exec").Value,
                                                             profile.Attribute("params").Value));
                            }
                        }

                        listBox1.DisplayMember = "Text";
                        listBox1.DataSource = items;

                        try
                        {
                            int i = Settings.DefaultProfile;
                            if (i < listBox1.Items.Count && i >= 0) listBox1.SelectedIndex = i;
                        }
                        catch (Exception ex)
                        {
                            listBox1.SelectedIndex = 0;
                        }
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
                var startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = Settings.GamePath;
                startInfo.FileName = ((LaunchProfile)listBox1.SelectedItem).Exec;
                startInfo.Arguments = ((LaunchProfile)listBox1.SelectedItem).Params;
                startInfo.Arguments += " " + Settings.GameParams;

                Settings.DefaultProfile = listBox1.SelectedIndex;

                Process.Start(startInfo);
                if (Settings.QuitOnLaunch) Application.Exit();


            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, this.Name + ".btnPlay_Click");
            }
        }

        private void btnScreenshots_Click(object sender, EventArgs e)
        {
            try {
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
            WorkThread.Kill = true;
            DirCopy.Kill = true;

            if(myCopyDirThread != null) if(myCopyDirThread.IsAlive) try { myCopyDirThread.Abort(); } catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Preferences prefs = new Preferences();
            prefs.btnRevalidate.Enabled = (myWorker.Status == "Done");
            prefs.ShowDialog(this);
            Skin();

            if (prefs.ReValidate)
            {
                try
                {
                    File.Delete(Path.Combine(Settings.GamePath, "tequilalog.xml"));
                    timer1.Enabled = Setup();
                    StartUp();
                }
                catch (Exception ex)
                {
                    MyToolkit.ErrorReporter(ex, this.Name + ".Form_Load");
                }
            }
        }

    }
}
