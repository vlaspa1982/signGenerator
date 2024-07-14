using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signature
{
    public partial class MyMessageBoxYesNoCancel : Form
    {
        public MyMessageBoxYesNoCancel(string message, string title)
        {
            InitializeComponent();
            richTextBox1.Text = "\r\n" + message;
            this.Text = title;
            if (title.Contains("Warning"))
            {
                this.Icon = SystemIcons.Warning;
            }
            else
            {
                this.Icon = SystemIcons.Information;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
