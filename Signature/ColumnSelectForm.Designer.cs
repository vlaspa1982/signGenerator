namespace Signature
{
    partial class ColumnSelectForm
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
            button1 = new Button();
            checkedListBox1 = new CheckedListBox();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(302, 11);
            button1.Name = "button1";
            button1.Size = new Size(87, 28);
            button1.TabIndex = 0;
            button1.Text = "Select";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.Control;
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 0);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(414, 383);
            checkedListBox1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 61);
            panel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(3, 27);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(74, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Select All";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(checkedListBox1);
            panel2.Location = new Point(10, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(414, 383);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(10, 450);
            panel3.Name = "panel3";
            panel3.Size = new Size(414, 51);
            panel3.TabIndex = 4;
            // 
            // ColumnSelectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 501);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximumSize = new Size(450, 740);
            Name = "ColumnSelectForm";
            Padding = new Padding(10, 0, 10, 0);
            StartPosition = FormStartPosition.CenterParent;
            Text = "ColumnSelectForm";
            Load += ColumnSelectForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private CheckedListBox checkedListBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private CheckBox checkBox1;
    }
}