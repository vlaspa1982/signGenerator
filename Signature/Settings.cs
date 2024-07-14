
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.ExceptionServices;

namespace Signature
{

    public partial class Settings : Form
    {

        public static Settings instanceSettingsForm;
        public static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        bool validationOutlookPath, validationBackupPath, validationOutputPath, validationDatabasePath, validationImagePath, validationTemplatePath;
        Service service = new Service();
        string _outlookDataRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "Signatures");

        public Settings()
        {
            InitializeComponent();
            instanceSettingsForm = this;
        }
        private void settingsBtnEnabled(bool btnEnabled)
        {
            tbBackupFolderPath.Enabled = btnEnabled;
            tbDatabasePath.Enabled = btnEnabled;
            tbImagePath.Enabled = btnEnabled;
            tbOutputFolderPath.Enabled = btnEnabled;
            tbTemplatePath.Enabled = btnEnabled;
            btnBackup.Enabled = btnEnabled;
            btnOpenBackUpPath.Enabled = btnEnabled;
            btnOpenImagePath.Enabled = btnEnabled;
            btnOpenTemplate.Enabled = btnEnabled;
            btnOpenOutputPath.Enabled = btnEnabled;
            btnOpenDatabase.Enabled = btnEnabled;
            btnSaveSettings.Enabled = btnEnabled;
            btnOpenOutlookPath.Enabled = btnEnabled;
            tbOutlookSignatures.Enabled = btnEnabled;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _logger.Info("Settings open.");
            string fileName = Application.UserAppDataPath + "\\" + "appSettings.json";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            SetUpToolTips();
            // show last selected path
            tbDatabasePath.Text = Generator.instance.DatabasePath;
            tbTemplatePath.Text = Generator.instance.TemplatePath;
            tbImagePath.Text = Generator.instance.ImagePath;
            tbOutputFolderPath.Text = Generator.instance.OutputPath;
            tbBackupFolderPath.Text = Generator.instance.BackupPath;
            tbOutlookSignatures.Text = Generator.instance.AppDataPath;
            if (!String.IsNullOrEmpty(tbBackupFolderPath.Text))
            {
                GetLastBackupDate();
            }
            chbDefaultFolder.Checked = false;
        }
        private void SetUpToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnOpenDatabase, "Set up database path.");
            ToolTip1.SetToolTip(this.btnOpenBackUpPath, "Set up backup folder.");
            ToolTip1.SetToolTip(this.btnOpenImagePath, "Set up folder with images.");
            ToolTip1.SetToolTip(this.btnOpenOutputPath, "Set up folder for created signatures.");
            ToolTip1.SetToolTip(this.btnOpenTemplate, "Set up folder with your templates.");
            ToolTip1.SetToolTip(this.tbDatabasePath, "Set up database path.");
            ToolTip1.SetToolTip(this.tbBackupFolderPath, "Set up backup folder.");
            ToolTip1.SetToolTip(this.tbImagePath, "Set up folder with images.");
            ToolTip1.SetToolTip(this.tbOutputFolderPath, "Set up folder for created signatures.");
            ToolTip1.SetToolTip(this.tbTemplatePath, "Set up folder with your templates.");
            ToolTip1.SetToolTip(this.btnBackup, "Copy your templates to backup folder.");
        }
        private void GetLastBackupDate()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(tbBackupFolderPath.Text);
            var dirs = directoryInfo.GetDirectories();
            var lastDir = dirs.LastOrDefault(x => x.Name.Contains("templ"));
            string last = lastDir != null ? "Last backup: " + lastDir.CreationTime.ToString() : "";
            lbLastBackup.Text = last;
        }


        //save settings
        private async void btnSaveSettings_Click(object sender, EventArgs e)
        {
            service = new Service();
            DataGridView dgw1 = GetDataGridView("dataGridView1");
            DataGridView dgw2 = GetDataGridView("dataGridView2");

            validationTemplatePath = ValidatePath(tbTemplatePath.Text, tbTemplatePath, label10, lbResult);
            validationImagePath = ValidatePath(tbImagePath.Text, tbImagePath, label9, lbResult);
            validationOutputPath = ValidatePath(tbOutputFolderPath.Text, tbOutputFolderPath, label6, lbResult);
            validationDatabasePath = ValidateFile(tbDatabasePath, label11);
            validationBackupPath = ValidatePath(tbBackupFolderPath.Text, tbBackupFolderPath, label7, lbResult);
            validationOutlookPath = ValidatePath(tbOutlookSignatures.Text, tbOutlookSignatures, label12, lbResult);

            bool validation = (validationTemplatePath && validationImagePath && validationOutputPath && validationDatabasePath && validationBackupPath && validationOutlookPath) ? true : false;
            if (validation)
            {
                SaveSettings(tbTemplatePath.Text, tbImagePath.Text, tbOutputFolderPath.Text, tbDatabasePath.Text, tbBackupFolderPath.Text, tbOutlookSignatures.Text);
                LoadDataToDataGridsAsync(tbDatabasePath.Text, dgw1, dgw2);
                await WriteJsonAsync();
                this.Close();
            }

            _logger.Info("Settings saved.");
        }

        private DataGridView GetDataGridView(string controlName)
        {
            FindControl findControl = new FindControl();
            return (DataGridView)findControl.Ctrl(Generator.instance, controlName);
        }

        private bool ValidatePath(string path, TextBox textBox, Label label, Label resultLabel)
        {
            bool isValid = Path.Exists(path);
            service.ShowIfIsValid(textBox, label, resultLabel, isValid);
            return isValid;
        }

        private bool ValidateFile(TextBox textBox, Label label)
        {
            bool isValid = File.Exists(textBox.Text);
            service.ShowIfIsValid(textBox, label, lbResult, isValid);
            return isValid;
        }

        private void SaveSettings(string templatePath, string imagePath, string outputPath, string databasePath, string backupPath, string outlookPath)
        {
            _logger.Info("Set up paths: successful.");
            Generator.instance.TemplatePath = templatePath;
            Generator.instance.ImagePath = imagePath;
            Generator.instance.OutputPath = outputPath;
            Generator.instance.DatabasePath = databasePath;
            Generator.instance.BackupPath = backupPath;
            Generator.instance.AppDataPath = outlookPath;
            Generator.instance.userHeaders = new List<string>();
            Generator.instance.templateHeaders = new List<string>();
        }

        private async void LoadDataToDataGridsAsync(string databasePath, DataGridView dgw1, DataGridView dgw2)
        {
            await service.LoadDataToDatagridAsync(databasePath, dgw1, dgw2);
            service.LoadHeaders(dgw1, Generator.instance.userHeaders);
            service.LoadHeaders(dgw2, Generator.instance.templateHeaders);
        }
       

        private async Task WriteJsonAsync()
        {
            try
            {
                var settingsPath = new SettingsPath
                {
                    BackupPath = tbBackupFolderPath.Text,
                    TemplatePath = tbTemplatePath.Text,
                    ImagePath = tbImagePath.Text,
                    OutputPath = tbOutputFolderPath.Text,
                    DatabasePath = tbDatabasePath.Text,
                    AppDataPath = tbOutlookSignatures.Text,
                };
                var fileName = Path.Combine(Application.UserAppDataPath, "appSettings.json");

                string jsonString = JsonSerializer.Serialize(settingsPath);
                await File.WriteAllTextAsync(fileName, jsonString);

                _logger.Info("Settings saved to JSON file successfully.");
            }
            catch (JsonException jsonEx)
            {
                _logger.Error("Failed to serialize settings to JSON.", jsonEx);
                MessageBox.Show("Error while saving settings to JSON. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                _logger.Error("Failed to write JSON file.", ioEx);
                MessageBox.Show("Error while writing JSON file. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                _logger.Error("Access denied while writing JSON file.", uaEx);
                MessageBox.Show("Access denied while saving settings. Please check your permissions and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.Error("An unexpected error occurred while saving settings.", ex);
                MessageBox.Show("An unexpected error occurred while saving settings. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // set folders
        private void btnOpenDatabase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xlsx|Excel Workbook|*.xls" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbDatabasePath.Text = dialog.FileName;
                }
            }
        }
        // set folders
        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            service.showDirectoryPath(tbTemplatePath);
        }
        private void btnOpenImagePath_Click(object sender, EventArgs e)
        {
            service.showDirectoryPath(tbImagePath);
        }
        private void btnOpenOutputPath_Click(object sender, EventArgs e)
        {
            service.showDirectoryPath(tbOutputFolderPath);
        }
        private void btnOpenBackUpPath_Click(object sender, EventArgs e)
        {
            service.showDirectoryPath(tbBackupFolderPath);
        }
        private void btnOpenOutlookPath_Click(object sender, EventArgs e)
        {
            service.showDirectoryPath(tbOutlookSignatures);
            chbDefaultFolder.Checked = false;
        }
        private void btnCloseSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            backUpCreate();
            settingsBtnEnabled(true);
        }

        private async Task backUpCreate()
        {

            _logger.Info("Backup templates: START *****");

            Service service = new Service();
            settingsBtnEnabled(false);

            bool validationBackupPath = ValidatePath(tbBackupFolderPath.Text, tbBackupFolderPath, label7, lbResult);
            bool validationTemplatePath = ValidatePath(tbTemplatePath.Text, tbTemplatePath, label10, lbResult);
            var templateInfo = new DirectoryInfo(tbTemplatePath.Text);

            try
            {
                if (validationBackupPath && validationTemplatePath)
                {
                    lbResult.Text = "Backup start. Please wait.";
                    if (templateInfo.GetDirectories().Length == 0)
                    {
                        settingsBtnEnabled(true);
                        MessageBox.Show("Folder with templates is empty.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    settingsBtnEnabled(false);

                    // Asynchronní vytvoření zálohy a čekání na její dokončení
                    await service.CreateBackUpAsync(tbTemplatePath.Text, tbBackupFolderPath.Text, "templ", pbSettings, true, true);
                    lbResult.Text = "Backup complete.";
                    lbResult.ForeColor = Color.DarkGreen;

                }
            }
            catch (Exception ex)
            {
                // Zaznamenání chyby a zobrazení chybové zprávy
                _logger.Error("Backup failed. " + ex.Message);
                lbResult.ForeColor = Color.Red;
                lbResult.Text = "Backup failed.";
            }
            finally
            {
                // Aktivace tlačítek bez ohledu na úspěch či selhání zálohování
                settingsBtnEnabled(true);
            }

            settingsBtnEnabled(true);
            _logger.Info("Backup templates: END *****");
        }

        private void chbDefaultFolder_CheckedChanged(object sender, EventArgs e)
        {

            if (chbDefaultFolder.Checked)
            {
                tbOutlookSignatures.Text = _outlookDataRoot;
            }
        }

       
    }
}

