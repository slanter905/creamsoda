namespace CreamSoda
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.ckbQuitOnLaunch = new System.Windows.Forms.CheckBox();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRevalidate = new System.Windows.Forms.Button();
            this.lbManifests = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddManifest = new System.Windows.Forms.Button();
            this.txtNewManifest = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInstallPathBrowse = new System.Windows.Forms.Button();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(94)))), ((int)(((byte)(112)))));
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(248, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(131, 33);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnColor.Location = new System.Drawing.Point(83, 11);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(67, 23);
            this.btnColor.TabIndex = 9;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Background";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Launch Parameters";
            // 
            // txtParameters
            // 
            this.txtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameters.Location = new System.Drawing.Point(111, 13);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(255, 20);
            this.txtParameters.TabIndex = 2;
            this.txtParameters.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ckbQuitOnLaunch
            // 
            this.ckbQuitOnLaunch.AutoSize = true;
            this.ckbQuitOnLaunch.Location = new System.Drawing.Point(113, 41);
            this.ckbQuitOnLaunch.Name = "ckbQuitOnLaunch";
            this.ckbQuitOnLaunch.Size = new System.Drawing.Size(218, 17);
            this.ckbQuitOnLaunch.TabIndex = 3;
            this.ckbQuitOnLaunch.Text = "Close CreamSoda after starting the game";
            this.ckbQuitOnLaunch.UseVisualStyleBackColor = true;
            this.ckbQuitOnLaunch.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnTextColor
            // 
            this.btnTextColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTextColor.Location = new System.Drawing.Point(190, 11);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(67, 23);
            this.btnTextColor.TabIndex = 11;
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Text";
            // 
            // btnRevalidate
            // 
            this.btnRevalidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevalidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRevalidate.Location = new System.Drawing.Point(116, 322);
            this.btnRevalidate.Name = "btnRevalidate";
            this.btnRevalidate.Size = new System.Drawing.Size(129, 33);
            this.btnRevalidate.TabIndex = 16;
            this.btnRevalidate.Text = "Re-Validate";
            this.btnRevalidate.UseVisualStyleBackColor = true;
            this.btnRevalidate.Click += new System.EventHandler(this.btnRevalidate_Click);
            // 
            // lbManifests
            // 
            this.lbManifests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbManifests.FormattingEnabled = true;
            this.lbManifests.Location = new System.Drawing.Point(6, 46);
            this.lbManifests.Name = "lbManifests";
            this.lbManifests.Size = new System.Drawing.Size(304, 82);
            this.lbManifests.TabIndex = 15;
            this.lbManifests.Click += new System.EventHandler(this.lbManifests_Click);
            this.lbManifests.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbManifests_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddManifest);
            this.groupBox1.Controls.Add(this.txtNewManifest);
            this.groupBox1.Controls.Add(this.lbManifests);
            this.groupBox1.Location = new System.Drawing.Point(7, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manifests";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(316, 46);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 82);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteManifest_Click);
            // 
            // btnAddManifest
            // 
            this.btnAddManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddManifest.Location = new System.Drawing.Point(316, 16);
            this.btnAddManifest.Name = "btnAddManifest";
            this.btnAddManifest.Size = new System.Drawing.Size(50, 23);
            this.btnAddManifest.TabIndex = 14;
            this.btnAddManifest.Text = "Add";
            this.btnAddManifest.UseVisualStyleBackColor = true;
            this.btnAddManifest.Click += new System.EventHandler(this.btnAddManifest_Click);
            // 
            // txtNewManifest
            // 
            this.txtNewManifest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewManifest.Location = new System.Drawing.Point(6, 18);
            this.txtNewManifest.Name = "txtNewManifest";
            this.txtNewManifest.Size = new System.Drawing.Size(304, 20);
            this.txtNewManifest.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnColor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnTextColor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 42);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colors";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnInstallPathBrowse);
            this.groupBox3.Controls.Add(this.lblInstallPath);
            this.groupBox3.Location = new System.Drawing.Point(9, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 46);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Install Path";
            // 
            // btnInstallPathBrowse
            // 
            this.btnInstallPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallPathBrowse.Location = new System.Drawing.Point(314, 15);
            this.btnInstallPathBrowse.Name = "btnInstallPathBrowse";
            this.btnInstallPathBrowse.Size = new System.Drawing.Size(50, 23);
            this.btnInstallPathBrowse.TabIndex = 6;
            this.btnInstallPathBrowse.Text = "Browse";
            this.btnInstallPathBrowse.UseVisualStyleBackColor = true;
            this.btnInstallPathBrowse.Click += new System.EventHandler(this.btnInstallPathBrowse_Click);
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstallPath.Location = new System.Drawing.Point(6, 19);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(302, 21);
            this.lblInstallPath.TabIndex = 5;
            this.lblInstallPath.Text = "label4";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtParameters);
            this.groupBox4.Controls.Add(this.ckbQuitOnLaunch);
            this.groupBox4.Location = new System.Drawing.Point(9, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(372, 63);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(384, 384);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRevalidate);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.CheckBox ckbQuitOnLaunch;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnRevalidate;
        private System.Windows.Forms.ListBox lbManifests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddManifest;
        private System.Windows.Forms.TextBox txtNewManifest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInstallPathBrowse;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDelete;
    }
}