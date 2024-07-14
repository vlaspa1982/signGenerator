namespace Signature
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            btnSaveSettings = new Button();
            label1 = new Label();
            tbDatabasePath = new TextBox();
            tbTemplatePath = new TextBox();
            label2 = new Label();
            tbImagePath = new TextBox();
            label3 = new Label();
            tbOutputFolderPath = new TextBox();
            label4 = new Label();
            tbBackupFolderPath = new TextBox();
            label5 = new Label();
            btnCloseSettings = new Button();
            btnOpenDatabase = new Button();
            btnOpenTemplate = new Button();
            btnOpenImagePath = new Button();
            btnOpenOutputPath = new Button();
            btnOpenBackUpPath = new Button();
            btnBackup = new Button();
            label6 = new Label();
            label7 = new Label();
            lbResult = new Label();
            panel1 = new Panel();
            pbSettings = new ProgressBar();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lbLastBackup = new Label();
            label8 = new Label();
            tbOutlookSignatures = new TextBox();
            label12 = new Label();
            btnOpenOutlookPath = new Button();
            chbDefaultFolder = new CheckBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveSettings.BackColor = SystemColors.ControlLightLight;
            btnSaveSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveSettings.Location = new Point(537, 513);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(68, 23);
            btnSaveSettings.TabIndex = 0;
            btnSaveSettings.Text = "OK";
            btnSaveSettings.UseVisualStyleBackColor = false;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(221, 236, 239);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Database path";
            // 
            // tbDatabasePath
            // 
            tbDatabasePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDatabasePath.Location = new Point(133, 29);
            tbDatabasePath.Name = "tbDatabasePath";
            tbDatabasePath.Size = new Size(498, 23);
            tbDatabasePath.TabIndex = 2;
            // 
            // tbTemplatePath
            // 
            tbTemplatePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTemplatePath.Location = new Point(133, 73);
            tbTemplatePath.Name = "tbTemplatePath";
            tbTemplatePath.Size = new Size(497, 23);
            tbTemplatePath.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(221, 236, 239);
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 6;
            label2.Text = "Template path";
            // 
            // tbImagePath
            // 
            tbImagePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbImagePath.BackColor = SystemColors.Window;
            tbImagePath.Location = new Point(133, 118);
            tbImagePath.Name = "tbImagePath";
            tbImagePath.Size = new Size(497, 23);
            tbImagePath.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(221, 236, 239);
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Image path";
            // 
            // tbOutputFolderPath
            // 
            tbOutputFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbOutputFolderPath.BackColor = SystemColors.Window;
            tbOutputFolderPath.Location = new Point(133, 166);
            tbOutputFolderPath.Name = "tbOutputFolderPath";
            tbOutputFolderPath.Size = new Size(497, 23);
            tbOutputFolderPath.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(221, 236, 239);
            label4.Location = new Point(9, 174);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 6;
            label4.Text = "Output folder path";
            // 
            // tbBackupFolderPath
            // 
            tbBackupFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbBackupFolderPath.Location = new Point(133, 213);
            tbBackupFolderPath.Name = "tbBackupFolderPath";
            tbBackupFolderPath.Size = new Size(497, 23);
            tbBackupFolderPath.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(221, 236, 239);
            label5.Location = new Point(9, 217);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 6;
            label5.Text = "BackUp folder path";
            // 
            // btnCloseSettings
            // 
            btnCloseSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseSettings.Location = new Point(622, 513);
            btnCloseSettings.Name = "btnCloseSettings";
            btnCloseSettings.Size = new Size(68, 23);
            btnCloseSettings.TabIndex = 1;
            btnCloseSettings.Text = "Close";
            btnCloseSettings.UseVisualStyleBackColor = true;
            btnCloseSettings.Click += btnCloseSettings_Click;
            // 
            // btnOpenDatabase
            // 
            btnOpenDatabase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenDatabase.Location = new Point(639, 30);
            btnOpenDatabase.Name = "btnOpenDatabase";
            btnOpenDatabase.Size = new Size(36, 23);
            btnOpenDatabase.TabIndex = 3;
            btnOpenDatabase.Text = "...";
            btnOpenDatabase.UseVisualStyleBackColor = true;
            btnOpenDatabase.Click += btnOpenDatabase_Click;
            // 
            // btnOpenTemplate
            // 
            btnOpenTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenTemplate.Location = new Point(638, 73);
            btnOpenTemplate.Name = "btnOpenTemplate";
            btnOpenTemplate.Size = new Size(36, 23);
            btnOpenTemplate.TabIndex = 5;
            btnOpenTemplate.Text = "...";
            btnOpenTemplate.UseVisualStyleBackColor = true;
            btnOpenTemplate.Click += btnOpenTemplate_Click;
            // 
            // btnOpenImagePath
            // 
            btnOpenImagePath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenImagePath.Location = new Point(638, 118);
            btnOpenImagePath.Name = "btnOpenImagePath";
            btnOpenImagePath.Size = new Size(36, 23);
            btnOpenImagePath.TabIndex = 7;
            btnOpenImagePath.Text = "...";
            btnOpenImagePath.UseVisualStyleBackColor = true;
            btnOpenImagePath.Click += btnOpenImagePath_Click;
            // 
            // btnOpenOutputPath
            // 
            btnOpenOutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenOutputPath.Location = new Point(638, 166);
            btnOpenOutputPath.Name = "btnOpenOutputPath";
            btnOpenOutputPath.Size = new Size(36, 23);
            btnOpenOutputPath.TabIndex = 9;
            btnOpenOutputPath.Text = "...";
            btnOpenOutputPath.UseVisualStyleBackColor = true;
            btnOpenOutputPath.Click += btnOpenOutputPath_Click;
            // 
            // btnOpenBackUpPath
            // 
            btnOpenBackUpPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenBackUpPath.Location = new Point(638, 213);
            btnOpenBackUpPath.Name = "btnOpenBackUpPath";
            btnOpenBackUpPath.Size = new Size(36, 23);
            btnOpenBackUpPath.TabIndex = 11;
            btnOpenBackUpPath.Text = "...";
            btnOpenBackUpPath.UseVisualStyleBackColor = true;
            btnOpenBackUpPath.Click += btnOpenBackUpPath_Click;
            // 
            // btnBackup
            // 
            btnBackup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackup.Location = new Point(600, 31);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(75, 23);
            btnBackup.TabIndex = 14;
            btnBackup.Text = "Backup";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 238);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(133, 192);
            label6.Name = "label6";
            label6.Size = new Size(257, 15);
            label6.TabIndex = 10;
            label6.Text = "Folder where your new signatures will be saved.";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(133, 239);
            label7.Name = "label7";
            label7.Size = new Size(171, 15);
            label7.TabIndex = 11;
            label7.Text = "Your backups will be save here.";
            // 
            // lbResult
            // 
            lbResult.AutoSize = true;
            lbResult.Location = new Point(13, 4);
            lbResult.Name = "lbResult";
            lbResult.Size = new Size(0, 15);
            lbResult.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(pbSettings);
            panel1.Controls.Add(lbResult);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 562);
            panel1.Name = "panel1";
            panel1.Size = new Size(721, 31);
            panel1.TabIndex = 14;
            // 
            // pbSettings
            // 
            pbSettings.Location = new Point(556, 10);
            pbSettings.Name = "pbSettings";
            pbSettings.Size = new Size(156, 12);
            pbSettings.TabIndex = 14;
            pbSettings.Visible = false;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 238);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(133, 144);
            label9.Name = "label9";
            label9.Size = new Size(154, 15);
            label9.TabIndex = 10;
            label9.Text = "Folder with personal photos.";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 238);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(133, 99);
            label10.Name = "label10";
            label10.Size = new Size(149, 15);
            label10.TabIndex = 10;
            label10.Text = "Folder with your templates.";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 238);
            label11.ForeColor = SystemColors.ControlDarkDark;
            label11.Location = new Point(133, 55);
            label11.Name = "label11";
            label11.Size = new Size(115, 15);
            label11.TabIndex = 10;
            label11.Text = "Excel with your data.";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(221, 236, 239);
            groupBox1.Controls.Add(tbBackupFolderPath);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnOpenBackUpPath);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(tbOutputFolderPath);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbDatabasePath);
            groupBox1.Controls.Add(btnOpenOutputPath);
            groupBox1.Controls.Add(tbTemplatePath);
            groupBox1.Controls.Add(btnOpenImagePath);
            groupBox1.Controls.Add(tbImagePath);
            groupBox1.Controls.Add(btnOpenTemplate);
            groupBox1.Controls.Add(btnOpenDatabase);
            groupBox1.Location = new Point(15, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(694, 265);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set up your file path";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.FromArgb(236, 236, 236);
            groupBox2.Controls.Add(lbLastBackup);
            groupBox2.Controls.Add(btnBackup);
            groupBox2.Location = new Point(15, 409);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(694, 69);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Backup your templates";
            // 
            // lbLastBackup
            // 
            lbLastBackup.AutoSize = true;
            lbLastBackup.Location = new Point(12, 37);
            lbLastBackup.Name = "lbLastBackup";
            lbLastBackup.Size = new Size(0, 15);
            lbLastBackup.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(9, 21);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 1;
            label8.Text = "Outlook folder";
            // 
            // tbOutlookSignatures
            // 
            tbOutlookSignatures.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbOutlookSignatures.ForeColor = SystemColors.ControlDarkDark;
            tbOutlookSignatures.Location = new Point(132, 21);
            tbOutlookSignatures.Name = "tbOutlookSignatures";
            tbOutlookSignatures.ReadOnly = true;
            tbOutlookSignatures.Size = new Size(498, 23);
            tbOutlookSignatures.TabIndex = 12;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(132, 47);
            label12.Name = "label12";
            label12.Size = new Size(167, 15);
            label12.TabIndex = 11;
            label12.Text = "Folder with Outlook signatures";
            // 
            // btnOpenOutlookPath
            // 
            btnOpenOutlookPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenOutlookPath.Location = new Point(638, 24);
            btnOpenOutlookPath.Name = "btnOpenOutlookPath";
            btnOpenOutlookPath.Size = new Size(36, 23);
            btnOpenOutlookPath.TabIndex = 18;
            btnOpenOutlookPath.Text = "...";
            btnOpenOutlookPath.UseVisualStyleBackColor = true;
            btnOpenOutlookPath.Click += btnOpenOutlookPath_Click;
            // 
            // chbDefaultFolder
            // 
            chbDefaultFolder.AutoSize = true;
            chbDefaultFolder.ForeColor = SystemColors.ControlDarkDark;
            chbDefaultFolder.Location = new Point(12, 74);
            chbDefaultFolder.Name = "chbDefaultFolder";
            chbDefaultFolder.RightToLeft = RightToLeft.No;
            chbDefaultFolder.Size = new Size(167, 19);
            chbDefaultFolder.TabIndex = 19;
            chbDefaultFolder.Text = "use default AppData folder";
            chbDefaultFolder.TextAlign = ContentAlignment.BottomCenter;
            chbDefaultFolder.UseVisualStyleBackColor = true;
            chbDefaultFolder.CheckedChanged += chbDefaultFolder_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Bisque;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(chbDefaultFolder);
            panel2.Controls.Add(btnOpenOutlookPath);
            panel2.Controls.Add(tbOutlookSignatures);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(15, 283);
            panel2.Name = "panel2";
            panel2.Size = new Size(694, 102);
            panel2.TabIndex = 22;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(721, 593);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnCloseSettings);
            Controls.Add(groupBox2);
            Controls.Add(btnSaveSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(535, 560);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSaveSettings;
        private Label label1;
        private TextBox tbDatabasePath;
        private TextBox tbTemplatePath;
        private Label label2;
        private TextBox tbImagePath;
        private Label label3;
        private TextBox tbOutputFolderPath;
        private Label label4;
        private TextBox tbBackupFolderPath;
        private Label label5;
        private Button btnCloseSettings;
        private Button btnOpenDatabase;
        private Button btnOpenTemplate;
        private Button btnOpenImagePath;
        private Button btnOpenOutputPath;
        private Button btnOpenBackUpPath;
        private Button btnBackup;
        private Label label6;
        private Label label7;
        private Label lbResult;
        private Panel panel1;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ProgressBar pbSettings;
        private Label lbLastBackup;
        private Label label8;
        private TextBox tbOutlookSignatures;
        private Label label12;
        private Button btnOpenOutlookPath;
        private CheckBox chbDefaultFolder;
        private Panel panel2;
    }
}