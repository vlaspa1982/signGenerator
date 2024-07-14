using System.Drawing.Printing;
using System.Windows.Forms;

namespace Signature
{
    partial class Generator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generator));
            contextMenuStrip1 = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            serviceBindingSource = new BindingSource(components);
            txtBoxBottomLog = new RichTextBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            chbClear = new CheckBox();
            panel1 = new Panel();
            panel20 = new Panel();
            menuStrip1 = new MenuStrip();
            btnGenerate = new ToolStripMenuItem();
            sendToOutlookMenuItem = new ToolStripMenuItem();
            sendBackFromOutlookToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            panel15 = new Panel();
            chbGenSelTemp = new CheckBox();
            splitContainer2 = new SplitContainer();
            splitContainer7 = new SplitContainer();
            panel19 = new Panel();
            panel14 = new Panel();
            label4 = new Label();
            richTextBox4 = new RichTextBox();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            panel16 = new Panel();
            label5 = new Label();
            richTextBox2 = new RichTextBox();
            panel17 = new Panel();
            label6 = new Label();
            richTextBox3 = new RichTextBox();
            panel18 = new Panel();
            label7 = new Label();
            richTextBox1 = new RichTextBox();
            panel7 = new Panel();
            panel11 = new Panel();
            panel8 = new Panel();
            panel10 = new Panel();
            panel21 = new Panel();
            label8 = new Label();
            comboBox1 = new ComboBox();
            menuStrip2 = new MenuStrip();
            selectColToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            panel9 = new Panel();
            panel2 = new Panel();
            chbAllUser = new CheckBox();
            panel6 = new Panel();
            label3 = new Label();
            panel13 = new Panel();
            dataGridView2 = new DataGridView();
            panel12 = new Panel();
            chbAllTem = new CheckBox();
            panel4 = new Panel();
            label2 = new Label();
            splitContainer6 = new SplitContainer();
            splitContainer1 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            panel3 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            pbForm1 = new ProgressBar();
            menuStrip3 = new MenuStrip();
            tsmLogs = new ToolStripMenuItem();
            lsmAbout = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel20.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.Panel1.SuspendLayout();
            splitContainer7.Panel2.SuspendLayout();
            splitContainer7.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel18.SuspendLayout();
            panel7.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel21.SuspendLayout();
            menuStrip2.SuspendLayout();
            panel9.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            menuStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(117, 26);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Service);
            // 
            // txtBoxBottomLog
            // 
            txtBoxBottomLog.BackColor = Color.WhiteSmoke;
            txtBoxBottomLog.Dock = DockStyle.Fill;
            txtBoxBottomLog.ForeColor = Color.White;
            txtBoxBottomLog.Location = new Point(0, 0);
            txtBoxBottomLog.Margin = new Padding(0);
            txtBoxBottomLog.Name = "txtBoxBottomLog";
            txtBoxBottomLog.ReadOnly = true;
            txtBoxBottomLog.Size = new Size(150, 46);
            txtBoxBottomLog.TabIndex = 0;
            txtBoxBottomLog.Text = "...";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(223, 239, 240);
            pictureBox1.Location = new Point(25, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1096, 299);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // chbClear
            // 
            chbClear.AutoSize = true;
            chbClear.BackColor = Color.White;
            chbClear.Checked = true;
            chbClear.CheckState = CheckState.Checked;
            chbClear.Location = new Point(149, 25);
            chbClear.Name = "chbClear";
            chbClear.Size = new Size(126, 19);
            chbClear.TabIndex = 3;
            chbClear.Text = "Clear output folder";
            chbClear.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(panel20);
            panel1.Controls.Add(panel15);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1096, 66);
            panel1.TabIndex = 22;
            // 
            // panel20
            // 
            panel20.Controls.Add(menuStrip1);
            panel20.Dock = DockStyle.Left;
            panel20.Location = new Point(0, 0);
            panel20.Name = "panel20";
            panel20.Padding = new Padding(10, 7, 5, 7);
            panel20.Size = new Size(442, 66);
            panel20.TabIndex = 22;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLightLight;
            menuStrip1.Dock = DockStyle.Right;
            menuStrip1.Font = new Font("Segoe UI", 10F);
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnGenerate, sendToOutlookMenuItem, sendBackFromOutlookToolStripMenuItem, settingsToolStripMenuItem1 });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(16, 7);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.Size = new Size(421, 52);
            menuStrip1.TabIndex = 1;
            menuStrip1.TabStop = true;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(211, 226, 229);
            btnGenerate.Image = (Image)resources.GetObject("btnGenerate.Image");
            btnGenerate.Margin = new Padding(0, 0, 5, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Padding = new Padding(0);
            btnGenerate.RightToLeft = RightToLeft.No;
            btnGenerate.Size = new Size(69, 52);
            btnGenerate.Text = "Generate";
            btnGenerate.TextAlign = ContentAlignment.BottomCenter;
            btnGenerate.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGenerate.ToolTipText = "Generate signatures";
            btnGenerate.Click += btnGenerate_Click;
            // 
            // sendToOutlookMenuItem
            // 
            sendToOutlookMenuItem.BackColor = SystemColors.Control;
            sendToOutlookMenuItem.Image = (Image)resources.GetObject("sendToOutlookMenuItem.Image");
            sendToOutlookMenuItem.Margin = new Padding(0, 0, 5, 0);
            sendToOutlookMenuItem.Name = "sendToOutlookMenuItem";
            sendToOutlookMenuItem.Size = new Size(122, 52);
            sendToOutlookMenuItem.Text = "Send to Outlook";
            sendToOutlookMenuItem.TextAlign = ContentAlignment.BottomCenter;
            sendToOutlookMenuItem.TextImageRelation = TextImageRelation.ImageAboveText;
            sendToOutlookMenuItem.ToolTipText = "Send the selected templates to Outlook for editing.";
            sendToOutlookMenuItem.Click += sendToOutlookStripMenuItem_Click;
            // 
            // sendBackFromOutlookToolStripMenuItem
            // 
            sendBackFromOutlookToolStripMenuItem.BackColor = SystemColors.Control;
            sendBackFromOutlookToolStripMenuItem.Image = (Image)resources.GetObject("sendBackFromOutlookToolStripMenuItem.Image");
            sendBackFromOutlookToolStripMenuItem.Margin = new Padding(0, 0, 5, 0);
            sendBackFromOutlookToolStripMenuItem.Name = "sendBackFromOutlookToolStripMenuItem";
            sendBackFromOutlookToolStripMenuItem.Size = new Size(138, 52);
            sendBackFromOutlookToolStripMenuItem.Text = "Send from Outlook";
            sendBackFromOutlookToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter;
            sendBackFromOutlookToolStripMenuItem.TextImageRelation = TextImageRelation.ImageAboveText;
            sendBackFromOutlookToolStripMenuItem.ToolTipText = "Send the edited templates back from Outlook to the templates folder.";
            sendBackFromOutlookToolStripMenuItem.Click += sendBackFromOutlookToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.BackColor = Color.Bisque;
            settingsToolStripMenuItem1.BackgroundImageLayout = ImageLayout.None;
            settingsToolStripMenuItem1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            settingsToolStripMenuItem1.Image = (Image)resources.GetObject("settingsToolStripMenuItem1.Image");
            settingsToolStripMenuItem1.ImageAlign = ContentAlignment.BottomCenter;
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.Padding = new Padding(5);
            settingsToolStripMenuItem1.Size = new Size(68, 52);
            settingsToolStripMenuItem1.Text = "Settings";
            settingsToolStripMenuItem1.TextImageRelation = TextImageRelation.ImageAboveText;
            settingsToolStripMenuItem1.ToolTipText = "Set up your folders.";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem1_Click;
            // 
            // panel15
            // 
            panel15.BackColor = Color.White;
            panel15.Controls.Add(chbGenSelTemp);
            panel15.Controls.Add(chbClear);
            panel15.Dock = DockStyle.Right;
            panel15.Location = new Point(813, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(283, 66);
            panel15.TabIndex = 21;
            // 
            // chbGenSelTemp
            // 
            chbGenSelTemp.AutoSize = true;
            chbGenSelTemp.Location = new Point(18, 25);
            chbGenSelTemp.Name = "chbGenSelTemp";
            chbGenSelTemp.Size = new Size(110, 19);
            chbGenSelTemp.TabIndex = 2;
            chbGenSelTemp.Tag = "";
            chbGenSelTemp.Text = "Show templates";
            chbGenSelTemp.UseVisualStyleBackColor = true;
            chbGenSelTemp.CheckedChanged += chbGenSelTemp_CheckedChanged;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer7);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1096, 250);
            splitContainer2.SplitterDistance = 283;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer7
            // 
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.Location = new Point(0, 0);
            splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            splitContainer7.Panel1.BackColor = Color.FromArgb(223, 239, 240);
            splitContainer7.Panel1.Controls.Add(pictureBox1);
            splitContainer7.Panel1.Controls.Add(panel19);
            // 
            // splitContainer7.Panel2
            // 
            splitContainer7.Panel2.BackColor = Color.FromArgb(233, 243, 244);
            splitContainer7.Panel2.Controls.Add(panel14);
            splitContainer7.Panel2.Controls.Add(richTextBox4);
            splitContainer7.Size = new Size(283, 250);
            splitContainer7.SplitterDistance = 137;
            splitContainer7.TabIndex = 9;
            // 
            // panel19
            // 
            panel19.BackColor = Color.FromArgb(213, 229, 230);
            panel19.Dock = DockStyle.Top;
            panel19.Location = new Point(0, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(137, 31);
            panel19.TabIndex = 8;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(213, 229, 230);
            panel14.Controls.Add(label4);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(142, 31);
            panel14.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 8);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 1;
            label4.Text = "Groups";
            // 
            // richTextBox4
            // 
            richTextBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox4.BackColor = Color.FromArgb(233, 243, 244);
            richTextBox4.BorderStyle = BorderStyle.None;
            richTextBox4.Location = new Point(12, 37);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(130, 213);
            richTextBox4.TabIndex = 0;
            richTextBox4.Text = "";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.BackColor = SystemColors.Control;
            splitContainer3.Panel2.Controls.Add(panel18);
            splitContainer3.Panel2.Controls.Add(richTextBox1);
            splitContainer3.Size = new Size(809, 250);
            splitContainer3.SplitterDistance = 580;
            splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.BackColor = Color.FromArgb(223, 239, 240);
            splitContainer4.Panel1.Controls.Add(panel16);
            splitContainer4.Panel1.Controls.Add(richTextBox2);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.BackColor = Color.FromArgb(233, 243, 244);
            splitContainer4.Panel2.Controls.Add(panel17);
            splitContainer4.Panel2.Controls.Add(richTextBox3);
            splitContainer4.Size = new Size(580, 250);
            splitContainer4.SplitterDistance = 294;
            splitContainer4.TabIndex = 0;
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(213, 229, 230);
            panel16.Controls.Add(label5);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(294, 31);
            panel16.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 8);
            label5.Name = "label5";
            label5.Size = new Size(22, 15);
            label5.TabIndex = 9;
            label5.Text = "CZ";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.BackColor = Color.FromArgb(223, 239, 240);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Location = new Point(15, 37);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(279, 213);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(223, 233, 234);
            panel17.Controls.Add(label6);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(0, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(282, 31);
            panel17.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 8);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 9;
            label6.Text = "EN";
            // 
            // richTextBox3
            // 
            richTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox3.BackColor = Color.FromArgb(233, 243, 244);
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Location = new Point(13, 37);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(269, 213);
            richTextBox3.TabIndex = 8;
            richTextBox3.Text = "";
            // 
            // panel18
            // 
            panel18.BackColor = SystemColors.ControlLight;
            panel18.Controls.Add(label7);
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(0, 0);
            panel18.Name = "panel18";
            panel18.Size = new Size(225, 31);
            panel18.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 8);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 9;
            label7.Text = "Templates";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(15, 37);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(210, 213);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel11);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1096, 360);
            panel7.TabIndex = 17;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(211, 226, 229);
            panel11.Controls.Add(dataGridView1);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 37);
            panel11.Name = "panel11";
            panel11.Size = new Size(1096, 323);
            panel11.TabIndex = 19;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(211, 226, 229);
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1096, 37);
            panel8.TabIndex = 18;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel21);
            panel10.Controls.Add(menuStrip2);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(740, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(356, 37);
            panel10.TabIndex = 50;
            // 
            // panel21
            // 
            panel21.Controls.Add(label8);
            panel21.Controls.Add(comboBox1);
            panel21.Dock = DockStyle.Left;
            panel21.Location = new Point(0, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(132, 37);
            panel21.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 11);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 6;
            label8.Text = "Font size";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" });
            comboBox1.Location = new Point(81, 7);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(43, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "9";
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.FromArgb(211, 226, 229);
            menuStrip2.BackgroundImageLayout = ImageLayout.None;
            menuStrip2.Dock = DockStyle.Right;
            menuStrip2.GripMargin = new Padding(0);
            menuStrip2.Items.AddRange(new ToolStripItem[] { selectColToolStripMenuItem, refreshToolStripMenuItem, editToolStripMenuItem });
            menuStrip2.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip2.Location = new Point(137, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new Padding(0);
            menuStrip2.Size = new Size(219, 37);
            menuStrip2.TabIndex = 6;
            menuStrip2.Text = "menuStrip2";
            // 
            // selectColToolStripMenuItem
            // 
            selectColToolStripMenuItem.BackColor = Color.FromArgb(211, 226, 229);
            selectColToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            selectColToolStripMenuItem.Image = (Image)resources.GetObject("selectColToolStripMenuItem.Image");
            selectColToolStripMenuItem.Name = "selectColToolStripMenuItem";
            selectColToolStripMenuItem.Size = new Size(88, 37);
            selectColToolStripMenuItem.Text = "Select col.";
            selectColToolStripMenuItem.ToolTipText = "Select visible collumns.";
            selectColToolStripMenuItem.Click += selectColToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.BackColor = Color.FromArgb(211, 226, 229);
            refreshToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            refreshToolStripMenuItem.Image = (Image)resources.GetObject("refreshToolStripMenuItem.Image");
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(74, 37);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.ToolTipText = "Refresh your database view.";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            editToolStripMenuItem.Image = (Image)resources.GetObject("editToolStripMenuItem.Image");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(55, 37);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.ToolTipText = "You can edit your database.";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel2);
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(356, 37);
            panel9.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(chbAllUser);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(356, 37);
            panel2.TabIndex = 16;
            // 
            // chbAllUser
            // 
            chbAllUser.AutoSize = true;
            chbAllUser.Location = new Point(12, 10);
            chbAllUser.Name = "chbAllUser";
            chbAllUser.RightToLeft = RightToLeft.No;
            chbAllUser.Size = new Size(74, 19);
            chbAllUser.TabIndex = 4;
            chbAllUser.Text = "Select All";
            chbAllUser.UseVisualStyleBackColor = true;
            chbAllUser.CheckedChanged += chbAllUser_CheckedChanged;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(211, 226, 229);
            panel6.Controls.Add(label3);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 336);
            panel6.Name = "panel6";
            panel6.Size = new Size(1096, 24);
            panel6.TabIndex = 15;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1020, 5);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 18;
            label3.Text = "row(s) 0/0";
            // 
            // panel13
            // 
            panel13.Controls.Add(dataGridView2);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 37);
            panel13.Name = "panel13";
            panel13.Size = new Size(96, 39);
            panel13.TabIndex = 17;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(96, 39);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // panel12
            // 
            panel12.BackColor = SystemColors.Control;
            panel12.Controls.Add(chbAllTem);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(96, 37);
            panel12.TabIndex = 16;
            // 
            // chbAllTem
            // 
            chbAllTem.AutoSize = true;
            chbAllTem.Location = new Point(19, 10);
            chbAllTem.Name = "chbAllTem";
            chbAllTem.RightToLeft = RightToLeft.No;
            chbAllTem.Size = new Size(74, 19);
            chbAllTem.TabIndex = 14;
            chbAllTem.Text = "Select All";
            chbAllTem.UseVisualStyleBackColor = true;
            chbAllTem.CheckedChanged += chbAllTem_CheckedChanged;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 76);
            panel4.Name = "panel4";
            panel4.Size = new Size(96, 24);
            panel4.TabIndex = 15;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(20, 5);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 18;
            label2.Text = "row(s) 0/0";
            // 
            // splitContainer6
            // 
            splitContainer6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer6.Location = new Point(5, 65);
            splitContainer6.Margin = new Padding(0);
            splitContainer6.Name = "splitContainer6";
            splitContainer6.Orientation = Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(txtBoxBottomLog);
            splitContainer6.Panel2Collapsed = true;
            splitContainer6.Size = new Size(1096, 614);
            splitContainer6.SplitterDistance = 509;
            splitContainer6.SplitterWidth = 6;
            splitContainer6.TabIndex = 28;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1096, 614);
            splitContainer1.SplitterDistance = 360;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Margin = new Padding(0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(panel6);
            splitContainer5.Panel1.Controls.Add(panel7);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(panel13);
            splitContainer5.Panel2.Controls.Add(panel4);
            splitContainer5.Panel2.Controls.Add(panel12);
            splitContainer5.Panel2Collapsed = true;
            splitContainer5.Size = new Size(1096, 360);
            splitContainer5.SplitterDistance = 884;
            splitContainer5.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(5, 685);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1096, 34);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLight;
            panel5.Controls.Add(pbForm1);
            panel5.Controls.Add(menuStrip3);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(849, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(247, 34);
            panel5.TabIndex = 2;
            // 
            // pbForm1
            // 
            pbForm1.Location = new Point(11, 11);
            pbForm1.Name = "pbForm1";
            pbForm1.Size = new Size(143, 12);
            pbForm1.TabIndex = 25;
            pbForm1.Visible = false;
            // 
            // menuStrip3
            // 
            menuStrip3.BackColor = SystemColors.ControlLight;
            menuStrip3.Dock = DockStyle.None;
            menuStrip3.Items.AddRange(new ToolStripItem[] { tsmLogs, lsmAbout });
            menuStrip3.Location = new Point(160, 4);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.Size = new Size(74, 24);
            menuStrip3.TabIndex = 3;
            menuStrip3.Text = "menuStrip3";
            // 
            // tsmLogs
            // 
            tsmLogs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsmLogs.Image = (Image)resources.GetObject("tsmLogs.Image");
            tsmLogs.Margin = new Padding(5, 0, 5, 0);
            tsmLogs.Name = "tsmLogs";
            tsmLogs.Size = new Size(28, 20);
            tsmLogs.Text = "adsf";
            tsmLogs.ToolTipText = "Open log file.";
            tsmLogs.Click += tsmLogs_Click;
            // 
            // lsmAbout
            // 
            lsmAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            lsmAbout.Image = (Image)resources.GetObject("lsmAbout.Image");
            lsmAbout.Name = "lsmAbout";
            lsmAbout.Size = new Size(28, 20);
            lsmAbout.Text = "asdf";
            lsmAbout.ToolTipText = "About";
            lsmAbout.Click += lsmAbout_Click;
            // 
            // Generator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1106, 719);
            Controls.Add(panel3);
            Controls.Add(splitContainer6);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(824, 720);
            Name = "Generator";
            Padding = new Padding(5, 0, 5, 0);
            Text = "Signature Generator";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer7.Panel1.ResumeLayout(false);
            splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel7.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel9.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private BindingSource serviceBindingSource;
        private RichTextBox txtBoxBottomLog;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private CheckBox chbClear;
        private Panel panel1;
        private CheckBox chbGenSelTemp;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView2;
        private CheckBox chbAllTem;
        private Panel panel4;
        private Panel panel6;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private SplitContainer splitContainer6;
        private Panel panel3;
        private Label label1;
        private Panel panel5;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private RichTextBox richTextBox4;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer5;
        private ProgressBar pbForm1;
        private SplitContainer splitContainer7;
        private Panel panel7;
        private Panel panel11;
        private Panel panel8;
        private Panel panel10;
        private Panel panel9;
        private Panel panel2;
        private CheckBox chbAllUser;
        private Panel panel13;
        private Panel panel12;
        private Panel panel15;
        private ComboBox comboBox1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem selectColToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnGenerate;
        private ToolStripMenuItem sendToOutlookMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private RichTextBox richTextBox3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Panel panel14;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel20;
        private ToolStripMenuItem sendBackFromOutlookToolStripMenuItem;
        private Panel panel21;
        private Label label8;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem tsmLogs;
        private ToolStripMenuItem lsmAbout;
    }
}
