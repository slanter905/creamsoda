using System.Drawing;

namespace CreamSoda
{
    partial class CreamSoda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreamSoda));
            this.lblStatus = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.pnlErrors = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnScreenshots = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.cbManifest = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pnlErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblStatus.Location = new System.Drawing.Point(9, 497);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(764, 21);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Starting...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(9, 473);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(761, 21);
            this.Progress.TabIndex = 6;
            // 
            // txtErrors
            // 
            this.txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrors.Location = new System.Drawing.Point(3, 35);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(756, 179);
            this.txtErrors.TabIndex = 2;
            // 
            // pnlErrors
            // 
            this.pnlErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlErrors.BackColor = System.Drawing.Color.Transparent;
            this.pnlErrors.Controls.Add(this.label1);
            this.pnlErrors.Controls.Add(this.txtErrors);
            this.pnlErrors.Location = new System.Drawing.Point(12, 12);
            this.pnlErrors.Name = "pnlErrors";
            this.pnlErrors.Size = new System.Drawing.Size(759, 217);
            this.pnlErrors.TabIndex = 3;
            this.pnlErrors.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Errors:";
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(8, 427);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(378, 40);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox1.BackColor = System.Drawing.SystemColors.Window;
            this.ListBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 25;
            this.ListBox1.Location = new System.Drawing.Point(9, 290);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(762, 104);
            this.ListBox1.TabIndex = 0;
            this.ListBox1.Click += new System.EventHandler(this.ListBox1_Click);
            this.ListBox1.DoubleClick += new System.EventHandler(this.btnPlay_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnScreenshots
            // 
            this.btnScreenshots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshots.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreenshots.Location = new System.Drawing.Point(392, 427);
            this.btnScreenshots.Name = "btnScreenshots";
            this.btnScreenshots.Size = new System.Drawing.Size(191, 40);
            this.btnScreenshots.TabIndex = 3;
            this.btnScreenshots.Text = "Screenshots";
            this.btnScreenshots.UseVisualStyleBackColor = true;
            this.btnScreenshots.Click += new System.EventHandler(this.btnScreenshots_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.Location = new System.Drawing.Point(590, 427);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(181, 40);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbManifest
            // 
            this.cbManifest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbManifest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManifest.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManifest.FormattingEnabled = true;
            this.cbManifest.Location = new System.Drawing.Point(10, 400);
            this.cbManifest.Name = "cbManifest";
            this.cbManifest.Size = new System.Drawing.Size(761, 21);
            this.cbManifest.TabIndex = 2;
            this.cbManifest.SelectedIndexChanged += new System.EventHandler(this.cbManifest_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 284);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // CreamSoda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.cbManifest);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnScreenshots);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.pnlErrors);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "CreamSoda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreamSoda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlErrors.ResumeLayout(false);
            this.pnlErrors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.Panel pnlErrors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnScreenshots;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ComboBox cbManifest;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

