using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outlook_Signature_Generator
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Otevření URL v výchozím webovém prohlížeči
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.amenit.cz", // Zde zadejte URL, kterou chcete otevřít
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Zpracování výjimky, pokud se něco pokazí
                MessageBox.Show($"Nelze otevřít odkaz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Sestavení mailto URI schématu
                string email = "amenit@amenit.cz"; // Zde zadejte e-mailovou adresu
                string subject = Uri.EscapeUriString("Dotaz z aplikace Outlook Generator"); // Zde zadejte předmět (volitelné)
                string body = Uri.EscapeUriString(""); // Zde zadejte tělo zprávy (volitelné)

                string mailtoUri = $"mailto:{email}?subject={subject}&body={body}";

                // Otevření e-mailového klienta s předvyplněnými údaji
                Process.Start(new ProcessStartInfo
                {
                    FileName = mailtoUri,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Zpracování výjimky, pokud se něco pokazí
                MessageBox.Show($"Nelze otevřít e-mailového klienta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
