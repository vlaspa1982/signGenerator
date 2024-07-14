namespace Signature
{
    partial class MyMessageBoxYesNo
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
            btnOk = new Button();
            btnNo = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(143, 84);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "Yes";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnNo
            // 
            btnNo.DialogResult = DialogResult.No;
            btnNo.Location = new Point(226, 84);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 23);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(24, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(299, 65);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // MyMessageBoxYesNo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 140);
            Controls.Add(richTextBox1);
            Controls.Add(btnNo);
            Controls.Add(btnOk);
            Name = "MyMessageBoxYesNo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MyMessageBoxYesNo";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOk;
        private Button btnNo;
        private RichTextBox richTextBox1;
    }
}