namespace Signature
{
    partial class MyMessageBoxYesNoCancel
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
            btnCancel = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(39, 91);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Yes";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnNo
            // 
            btnNo.DialogResult = DialogResult.No;
            btnNo.Location = new Point(129, 91);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 23);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(250, 91);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(29, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(296, 73);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // MyMessageBoxYesNoCancel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 138);
            Controls.Add(richTextBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnNo);
            Controls.Add(btnOk);
            Name = "MyMessageBoxYesNoCancel";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MyMessageBoxYesNoCancel";
            ResumeLayout(false);
        }

        #endregion
        private Button btnOk;
        private Button btnNo;
        private Button btnCancel;
        private RichTextBox richTextBox1;
    }
}