namespace Outlook_Signature_Generator
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            panel2 = new Panel();
            panel4 = new Panel();
            richTextBox2 = new RichTextBox();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 100);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(425, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(5, 372);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(425, 73);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 105);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(425, 267);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(richTextBox2);
            panel4.Controls.Add(linkLabel1);
            panel4.Controls.Add(linkLabel2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(5, 105);
            panel4.Name = "panel4";
            panel4.Size = new Size(415, 157);
            panel4.TabIndex = 4;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.Control;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Location = new Point(0, 6);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(412, 102);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "Amenit s.r.o.\nŽerotínova 2083/11\n741 01 Nový Jičín\n\n+420 556 706 203\n+420 222 360 250";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(0, 129);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(88, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "www.amenit.cz";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(0, 111);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(106, 15);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "amenit@amenit.cz";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(5, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(415, 100);
            panel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(303, 20);
            label3.TabIndex = 0;
            label3.Text = "Application: Outlook Signature Generator ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 34);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 0;
            label2.Text = "Version: 2.1.0.0";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 450);
            Controls.Add(panel2);
            Controls.Add(richTextBox1);
            Controls.Add(panel1);
            MaximumSize = new Size(451, 489);
            Name = "About";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private LinkLabel linkLabel1;
        private RichTextBox richTextBox2;
        private LinkLabel linkLabel2;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private Panel panel3;
    }
}