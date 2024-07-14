
using System.Data;
using ExcelDataReader;

using System.Diagnostics;
using System.Configuration;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NLog;
using System;
using ToolTip = System.Windows.Forms.ToolTip;
using Outlook_Signature_Generator;
using System.Numerics;

namespace Signature
{
    public partial class Generator : Form
    {
        public static Generator instance;
        public static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public bool ErrorExist { get; set; }
        List<DataGridViewRow> selectedUsers;
        public List<DataGridViewRow> selectedTemplates { get; set; }
        List<DataGridViewRow> selectedGroups;
        Service service;
        BindingSource usersBindingSource = new BindingSource();
        List<string> Suffixes = new List<string> { ".txt", ".rtf", ".htm" };
        public List<string> userHeaders { get; set; }
        public List<string> templateHeaders { get; set; }
        DataSet data;
        string userLogin;
        public string TemplateName { get; set; }
        string templatePath;
        string userOutputPath;
        string pathWithSuffix;
        public int FontSize { get; set; }
        public string MissingSubString { get; set; }
        public string ErrorDate { get; set; }
        public int NumberOfTemplates { get; set; }

        public string DatabasePath { get; set; }
        public string TemplatePath { get; set; }
        public string ImagePath { get; set; }
        public string OutputPath { get; set; }
        public string BackupPath { get; set; }
        public string AppDataPath { get; set; }
        public List<ShowColumns> ShowColumns { get; set; }
        string _outlookDataRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "Signatures");
        string _newMessageTxt = "DefaultMessageSignature-New.txt";
        string _replyMessageTxt = "DefaultMessageSignature-Reply.txt";
        string _userName = Environment.UserName;


        public Generator()
        {
            InitializeComponent();

            instance = this;
            List<DataGridViewRow> selectedUsers = this.selectedUsers;
            List<DataGridViewRow> selectedTemplates = this.selectedTemplates;
            List<DataGridViewRow> selectedGroups = this.selectedGroups;
            Service service = this.service;
            List<string> userHeaders = this.userHeaders;
            List<string> templateHeaders = this.templateHeaders;
            DataSet data = this.data;
            string MissingSubString = this.MissingSubString;

        }
        private void InitializeForm()
        {
            SetUpToolTips();
            _logger.Info("Application: LOADING.");
            service = new Service();
            txtBoxBottomLog.Text = "For more information, see the Logs folder in the application root. \n";
            txtBoxBottomLog.ForeColor = Color.Black;
            if (string.IsNullOrEmpty(AppDataPath))
            {
                AppDataPath = _outlookDataRoot;
            }
        }
        private void LoadSettingsForm()
        {
            string fileName = Path.Combine(Application.UserAppDataPath, "appSettings.json");
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    SettingsPath settingsPath = JsonSerializer.Deserialize<SettingsPath>(jsonString);
                    DatabasePath = File.Exists(settingsPath?.DatabasePath) ? settingsPath?.DatabasePath : null;
                    TemplatePath = Directory.Exists(settingsPath?.TemplatePath) ? settingsPath?.TemplatePath : null;
                    ImagePath = Directory.Exists(settingsPath?.ImagePath) ? settingsPath?.ImagePath : null;
                    OutputPath = Directory.Exists(settingsPath?.OutputPath) ? settingsPath?.OutputPath : null;
                    BackupPath = Directory.Exists(settingsPath?.BackupPath) ? settingsPath?.BackupPath : null;
                    AppDataPath = Directory.Exists(settingsPath?.AppDataPath) ? settingsPath?.AppDataPath : _outlookDataRoot;
                }
            }
        }
        private async void InitializeDataGrids()
        {
            await service.LoadDataToDatagridAsync(DatabasePath, dataGridView1, dataGridView2);
           
            service.InitializeDataGridView(dataGridView1);
            service.InitializeDataGridView(dataGridView2);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Rows[0].Selected = true;
                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));
            }
            label3.Text = $"row(s) {dataGridView1.SelectedRows.Count}/{dataGridView1.Rows.Count}";
            label2.Text = $"row(s) {dataGridView2.SelectedRows.Count}/{dataGridView2.Rows.Count}";
        }

        private void HandleException(string logMessage, Exception ex, string userMessage)
        {
            _logger.Error(logMessage, ex);
            MessageBox.Show(userMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeForm();
                LoadSettingsForm();
                InitializeDataGrids();
            }
            catch (JsonException jsonEx)
            {
                HandleException("Failed to deserialize settings from JSON.", jsonEx, "Error while loading settings from JSON. Please check the logs for more details.");
            }
            catch (IOException ioEx)
            {
                HandleException("File operation failed.", ioEx, "Error while reading settings file. Please check the logs for more details.");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                HandleException("Access denied while reading settings file.", uaEx, "Access denied while loading settings. Please check your permissions and try again.");
            }
            catch (Exception ex)
            {
                HandleException("An unexpected error occurred while loading the form.", ex, "An unexpected error occurred while loading the form. Please check the logs for more details.");
            }
        }

        private void SetUpToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.chbAllTem, "Select all templates.");
            ToolTip1.SetToolTip(this.chbAllUser, "Select all users.");
            ToolTip1.SetToolTip(this.chbGenSelTemp, "Show all templates in database.");
            ToolTip1.SetToolTip(this.chbClear, "All your created signatures will be cleared before creating new.");
          
            menuStrip3.ShowItemToolTips = true;
            menuStrip2.ShowItemToolTips = true;
            menuStrip1.ShowItemToolTips = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetRichTextBoxes();
            label1.Text = "Click on Generate and create your signatures.";
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView1.CurrentRow.Index;

            LoadImageAfterRowClick(rowClicked);
            DisplayUserGroups(rowClicked);
            DisplayTemplates(rowClicked);
            DisplayUserDetails(rowClicked);
            label3.Text = $"row(s) {dataGridView1.SelectedRows.Count}/{dataGridView1.Rows.Count}";
            chbAllUser.Checked = false;
        }
        private void ResetRichTextBoxes()
        {
            richTextBox1.ResetText();
            richTextBox2.ResetText();
            richTextBox3.ResetText();
            richTextBox4.ResetText();
        }
        private void LoadImageAfterRowClick(int rowIndex)
        {
            string imageURL = Path.Combine(ImagePath, $"{dataGridView1.Rows[rowIndex].Cells[0].Value}.png");
            string defaultUrl = Path.Combine(ImagePath, "image001.png");
            try
            {
                pictureBox1.Load(imageURL);
            }
            catch (Exception)
            {
                pictureBox1.Load(defaultUrl);
            }
        }
        private void DisplayUserGroups(int rowIndex)
        {
            string content = dataGridView1.Rows[rowIndex].Cells[dataGridView1.Columns["group"].Index].Value.ToString();
            string[] parts = content.Split(';');
            richTextBox4.Text = $"- {string.Join("\n- ", parts)}";
        }
        private void DisplayTemplates(int rowIndex)
        {
            List<DataGridViewRow> templates = service.GetTemplatesOfGroup(dataGridView1, dataGridView2, dataGridView1.Rows[rowIndex]);
            foreach (DataGridViewRow template in templates)
            {
                richTextBox1.Text += template.Cells[0].Value.ToString() + "\n";
            }
        }

        private void DisplayUserDetails(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            var titulPred = row.Cells["titulpred"].Value.ToString();
            var displayName = row.Cells["displayName"].Value.ToString();
            var titulZa = row.Cells["titulza"].Value.ToString();
            var funkce = row.Cells["funkce"].Value.ToString() + "\n";
            var firma = row.Cells["firma"].Value.ToString() + "\n";
            var funkce1 = row.Cells["funkce1"].Value.ToString() + "\n";
            var funkce2 = row.Cells["funkce2"].Value.ToString() + "\n";
            var email = row.Cells["email"].Value.ToString() + "\n";
            var telefon = row.Cells["telefon"].Value.ToString() + "\n";
            var telefon2 = row.Cells["telefon2"].Value.ToString() + "\n";
            var mobil = row.Cells["mobil"].Value.ToString() + "\n";
            var ulice = row.Cells["ulice"].Value.ToString() + "\n";
            var mesto = row.Cells["mesto"].Value.ToString();
            var psc = row.Cells["psc"].Value.ToString();
            var zpravaEn = row.Cells["zprava-en"].Value.ToString() + "\n\n";
            var funkceEn = row.Cells["funkce-en"].Value.ToString() + "\n";
            var funkce1En = row.Cells["funkce1-en"].Value.ToString() + "\n";
            var funkce2En = row.Cells["funkce2-en"].Value.ToString() + "\n";
            var zprava = row.Cells["zprava"].Value.ToString() + "\n\n";

            richTextBox2.Text = $"{zprava}{titulPred} {displayName} {titulZa} \n\n{funkce}{firma}{funkce1}{funkce2}" +
                                $"{email}{telefon}{telefon2}{mobil}\n{ulice}{psc} {mesto}";

            richTextBox3.Text = $"{zpravaEn}{titulPred}{displayName} {titulZa} \n\n{funkceEn}{firma}{funkce1En}{funkce2En}" +
                                $"{email}{telefon}{telefon2}{mobil}\n{ulice}{psc} {mesto}";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = $"row(s) {dataGridView2.SelectedRows.Count}/{dataGridView2.Rows.Count}";
            chbAllTem.Checked = false;
        }
        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();
            settingsForm.ShowDialog();
        }

        private void chbAllTem_CheckedChanged(object sender, EventArgs e)
        {
            service.AllCheckedChange(dataGridView2, chbAllTem, label2);
        }
        private void chbAllUser_CheckedChanged(object sender, EventArgs e)
        {
            service.AllCheckedChange(dataGridView1, chbAllUser, label3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(AppContext.BaseDirectory + "\\" + "Logs");
            var latestFile = dirInfo.GetFiles()
                .OrderByDescending(f => f.CreationTime)
                .FirstOrDefault().ToString();
            try
            {
                // Otevøení URL v výchozím webovém prohlížeèi
                Process.Start(new ProcessStartInfo
                {
                    FileName = latestFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Zpracování výjimky, pokud se nìco pokazí
                MessageBox.Show($"Nelze otevøít odkaz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task CopyImageAsync()
        {
            try
            {
                _logger.Info("Personal image was copied...");
                string imgP = ImagePath + "\\" + userLogin + ".png";
                string imgDestP = OutputPath + "\\" + userLogin + "\\" + TemplateName + "_files" + "\\" + "image001.png";
                if (File.Exists(imgP))
                {
                    await Task.Run(() => File.Copy(imgP, imgDestP, true));
                }
                else
                {
                    ErrorExist = true;
                    _logger.Error($"User {userLogin} does not have personal picture.");
                    txtBoxBottomLog.ForeColor = Color.Yellow;
                    txtBoxBottomLog.AppendText($"{ErrorDate}: User {userLogin} does not have personal picture. \n");
                }
            }
            catch (FileNotFoundException exception)
            {
                _logger.Error($"{exception.Message} User {userLogin} does not have personal picture.");
            }
            catch (IOException copyError)
            {
                _logger.Error(copyError.Message);
            }
        }

        private void chbGenSelTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbGenSelTemp.Checked)
            {
                splitContainer5.Panel2Collapsed = false;
            }
            else
            {
                splitContainer5.Panel2Collapsed = true;
            }
        }
        private async Task GenerateTemplatesAsync(DataGridViewRow uRow)
        {
            try
            {

                foreach (DataGridViewRow tRow in selectedTemplates)
                {
                    userHeaders = new List<string>();
                    templateHeaders = new List<string>();
                    service.LoadHeaders(dataGridView1, userHeaders);
                    service.LoadHeaders(dataGridView2, templateHeaders);
                    //variable login from database
                    userLogin = uRow.Cells[0].Value.ToString();
                    //variable name of template from database
                    TemplateName = tRow.Cells[0].Value.ToString();
                    templatePath = TemplatePath + "\\" + TemplateName;
                    userOutputPath = OutputPath + "\\" + userLogin;

                    _logger.Info($"Signature template {TemplateName} creating: Start.");
                    // check if template exist in template source directory
                    try
                    {

                        if (Directory.Exists(templatePath))
                        {
                            await service.CopyDirectoryAsync(templatePath, userOutputPath, true);
                            tRow.ErrorText = null;
                        }
                        else
                        {
                            ErrorExist = true;
                            _logger.Error($"Missing template name {TemplateName} in Template source directory  ");
                            txtBoxBottomLog.ForeColor = Color.Red;
                            txtBoxBottomLog.AppendText($"{ErrorDate}: Missing template name {TemplateName} in Template source directory \n");
                            tRow.ErrorText = "Missing template";
                            break;
                        }
                        //create directory (name as login) in output Directory and copy source directory of templates
                        tRow.ErrorText = null;


                        foreach (var suffix in Suffixes)
                        {
                            MissingSubString = "";

                            //new template path with file and suffix
                            pathWithSuffix = userOutputPath + "\\" + TemplateName + suffix;
                            await service.ChangeTemplatesTextAsync(uRow, pathWithSuffix, userHeaders);
                            if (MissingSubString != "")
                            {
                                ErrorExist = true;
                                _logger.Error($"Missing variable {MissingSubString} in template {TemplateName + suffix}");
                                txtBoxBottomLog.AppendText($"{ErrorDate}: Variable {MissingSubString} in {TemplateName + suffix} is not in database.");
                                txtBoxBottomLog.ForeColor = Color.Red;
                                tRow.ErrorText = $"Missing variable(s) {MissingSubString} .";

                                break;
                            }
                        }
                    }
                    catch (IOException ioEx)
                    {
                        ErrorExist = true;
                        _logger.Error(ioEx.Message, $"I/O error occurred.");
                        MessageBox.Show("I/O error occurred. Show logs for more information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Pokraèujte v ošetøení dalších výjimek nebo v návratu chyby
                    }
                    catch (Exception ex)
                    {
                        ErrorExist = true;
                        _logger.Error(ex.Message, $"Error occurred while generating templates.");
                        MessageBox.Show("Error occurred while generating templates. Show logs for more information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Pokraèujte v ošetøení dalších výjimek nebo v návratu chyby
                    }

                    if (tRow.Cells[dataGridView2.Columns["image"].Index].Value.ToString() == "image001")
                    {
                        
                        await CopyImageAsync();
                    }

                }
                _logger.Info($"Signature template {TemplateName} creating: End.");
            }
            catch (Exception ex)
            {
                ErrorExist = true;
                _logger.Error(ex.Message, $"Error occurred while iterating through selected templates.");
                MessageBox.Show("Error occurred while iterating through selected templates. Show logs for more information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task SendSignaturesToBackupAsync()
        {
            if (!Directory.Exists(AppDataPath))
                _logger.Error(new DirectoryNotFoundException($"Outlook signatures directory not found"));
            await service.BackUpMySignatureAsync(AppDataPath, BackupPath, true);

        }
        private async Task SendBackTemplatesAsync()
        {
            string newDirectory;
            var _destination = new DirectoryInfo(TemplatePath);
            var _source = new DirectoryInfo(AppDataPath);
            if (!_source.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {_source.FullName}");
            FileInfo[] sourceFiles = _source.GetFiles();
            DirectoryInfo[] sourceDirs = _source.GetDirectories();

            //vytvoøení složek v adresáøi s templates
            await CreateDirectoriesAsync(sourceFiles, _destination);

            label1.Text = "Copying files, please wait.";

            // kopírování files do složek podle názvù
            await CopyFilesToDirectoriesAsync(sourceFiles, _destination.GetDirectories());

            label1.Text = "Copying directories, please wait.";
            await CopyDirectoriesAsync(sourceDirs, TemplatePath);

            // Dokonèení progress baru
            FinalizeProgressBar();

            // Zobrazení zprávy o dokonèení
            ShowCompletionMessage();
        }
        private async Task CopyDirectoriesAsync(DirectoryInfo[] sourceDirs, string templatePath)
        {
            foreach (var subDir in sourceDirs)
            {
                var name = Regex.Replace(subDir.Name, "_[^_]+$", "");
                string newDestinationDir = Path.Combine(templatePath, name, subDir.Name);
                Directory.CreateDirectory(newDestinationDir);

                foreach (var f in subDir.GetFiles())
                {
                    var newFileName = Path.Combine(newDestinationDir, f.Name);
                    // f.CopyTo(newFileName, true);
                    await CopyFileAsync(f.FullName, newFileName);
                }
                await Task.Yield(); // Umožní asynchronní operaci
            }
        }
        private async Task CreateDirectoriesAsync(FileInfo[] sourceFiles, DirectoryInfo destination)
        {
            foreach (var f in sourceFiles)
            {
                label1.Text = "Copying folder. Please wait.";
                var name = Regex.Replace(f.Name, "\\.[^.]+$", "");
                var newDirectory = Path.Combine(destination.FullName, name);
                Directory.CreateDirectory(newDirectory);
                await Task.Yield(); // Umožní asynchronní operaci
            }
        }
        private async Task CopyFilesToDirectoriesAsync(FileInfo[] sourceFiles, DirectoryInfo[] destinationDirs)
        {
            var pbForm1Value = 0;
            foreach (var f in sourceFiles)
            {
                pbForm1.Maximum = sourceFiles.Length;
                pbForm1Value++;
                pbForm1.Value = pbForm1Value;
                var nameLikeNewFolder = Regex.Replace(f.Name, "\\.[^.]+$", "");
                foreach (var tempDirection in destinationDirs)
                {
                    if (nameLikeNewFolder == tempDirection.Name)
                    {
                        string targetFilePath = Path.Combine(tempDirection.FullName, f.Name);
                        await CopyFileAsync(f.FullName, targetFilePath);
                    }
                }
                await Task.Yield(); // Umožní asynchronní operaci
            }
        }

        private async Task CopyFileAsync(string sourceFilePath, string destinationFilePath)
        {
            const int bufferSize = 81920; // 80 KB
            using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
            using (var destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, useAsync: true))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
        }
        private void FinalizeProgressBar()
        {
            label1.Text = "The templates were sent back from Outlook.";
            pbForm1.Value = 0;
            pbForm1.Visible = false;
        }

        private void ShowCompletionMessage()
        {
            MessageBox.Show("Your templates have been copied back from Outlook.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            InitializeProcess("");
            _logger.Info("Generating: START. **********");

            if (!ValidateInputs())
            {
                FinalizeProcess("Process stoped.");
                return;
            }

            if (await ConfirmBackupAsync())
            {
                label1.Text = "Generating... Please wait.";
                await GenerateSignaturesAsync();
            }
            _logger.Info("Generating: END. ********** \n\n");
            FinalizeProcess("Generating complete.");
        }

        private void InitializeProcess(string message)
        {
            pbForm1.Visible = true;
            pbForm1.Value = 0;
            label1.ForeColor = default;
            label1.Text = message;

            ErrorExist = false;
            btnEnabled(false);
        }

        private bool ValidateInputs()
        {

            if (dataGridView1.SelectedRows.Count == 0 && !String.IsNullOrWhiteSpace(DatabasePath))
            {
                MessageBox.Show("Select at least one user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label1.Text = "";
                return false;
            }

            if (string.IsNullOrWhiteSpace(DatabasePath) ||
                string.IsNullOrWhiteSpace(TemplatePath) ||
                string.IsNullOrWhiteSpace(OutputPath) ||
                string.IsNullOrWhiteSpace(BackupPath) ||
                string.IsNullOrWhiteSpace(ImagePath))
            {
                MessageBox.Show("Go to Settings and set up your folders first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private async Task<bool> ConfirmBackupAsync()
        {
            MyMessageBoxYesNoCancel mb1 = new MyMessageBoxYesNoCancel("Do you want to backup last generated signatures?", "Warning!");
            mb1.ShowDialog();

            if (mb1.DialogResult == DialogResult.Cancel)
            {
                return false;
            }

            if (mb1.DialogResult == DialogResult.OK)
            {
                InitializeProcess("Backup start. Please wait.");
                await service.CreateBackUpAsync(OutputPath, BackupPath, "sign", pbForm1, true, false);
                FinalizeProcess("Backup complete.");
            }

            return true;
        }

        private async Task GenerateSignaturesAsync()
        {
            selectedUsers = new List<DataGridViewRow>();
            selectedTemplates = new List<DataGridViewRow>();
            service.GetSelectedUserRow(selectedUsers, dataGridView1);
            service.GetSelectedTemplateRow(selectedTemplates, dataGridView2);

            pbForm1.Maximum = selectedUsers.Count;

            if (chbClear.Checked)
            {
                label1.Text = "Clearing folder with signatures.";
                await service.ClearFolderAsync(OutputPath);
                _logger.Info("Clear folder with signature.");
                label1.Text = "Clearing complete.";
            }

            NumberOfTemplates = selectedUsers.Count * selectedTemplates.Count;
            ErrorDate = DateTime.Now.ToString("HH:mm:ss");

            int pbFormValue = 0;
            label1.Text = "Generating signature(s). Please wait.";

            foreach (DataGridViewRow uRow in selectedUsers)
            {
                pbFormValue++;
                pbForm1.Value = pbFormValue;
                label1.Text = "Generating signatures: " + uRow.Cells["login"].Value.ToString();

                if (!chbGenSelTemp.Checked)
                {
                    selectedTemplates = service.GetTemplatesOfGroup(dataGridView1, dataGridView2, uRow);
                }

                var login = uRow.Cells["login"].Value.ToString();
                var newMessage = uRow.Cells["NewMessageSignature"].Value.ToString();
                var replyMessage = uRow.Cells["ReplyMessageSignature"].Value.ToString();
                var newMessagePath = Path.Combine(OutputPath, login, _newMessageTxt);
                var replyMessagePath = Path.Combine(OutputPath, login, _replyMessageTxt);

                _logger.Info($"User {login}, signature generating: Start. ***");
                await GenerateTemplatesAsync(uRow);

                if (!ErrorExist)
                {
                    File.WriteAllText(newMessagePath, newMessage);
                    File.WriteAllText(replyMessagePath, replyMessage);
                }

                _logger.Info($"User {login}, signature generating: End.");
            }
            FinalizeProcess("Generating signature(s) complete.");

            if (ErrorExist)
            {

                MessageBox.Show("The process encountered errors. Please check the log.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label1.ForeColor = Color.Red;
                label1.Text = "The process encountered errors. Please check the log.";
            }
            else
            {
                MessageBox.Show($"Well done, you have created the {selectedUsers.Count} users signatures.", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
                label1.Text = $"Signatures for {selectedUsers.Count} user(s) were created. You can generate more signatures.";
            }
        }

        private void FinalizeProcess(string message)
        {
            label1.Text = message;
            pbForm1.Value = 0;
            pbForm1.Visible = false;
            btnEnabled(true);
        }


        private void btnEnabled(bool btnEnabled)
        {
            btnGenerate.Enabled = btnEnabled;
            sendToOutlookMenuItem.Enabled = btnEnabled;
            sendBackFromOutlookToolStripMenuItem.Enabled = btnEnabled;
            settingsToolStripMenuItem1.Enabled = btnEnabled;
            chbClear.Enabled = btnEnabled;
            chbGenSelTemp.Enabled = btnEnabled;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            var fontSize = Convert.ToInt32(comboBox1.Text);
            if (Convert.ToInt32(comboBox1.Text) >= 8)
            {
                System.Drawing.Font f = new System.Drawing.Font("Segoe", fontSize);
                dataGridView1.RowsDefaultCellStyle.Font = f;
                dataGridView2.RowsDefaultCellStyle.Font = f;
            }
        }

        private void selectColToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            ColumnSelectForm colForm = new ColumnSelectForm();
            ShowColumns = new List<ShowColumns>();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                var col = dataGridView1.Columns[i];
                if (col.Visible == true)
                {
                    ShowColumns.Add(new ShowColumns
                    {
                        ColName = col.HeaderCell.Value.ToString(),
                        ColVisible = true
                    });
                }
                else
                {
                    ShowColumns.Add(new ShowColumns
                    {
                        ColName = col.HeaderCell.Value.ToString(),
                        ColVisible = false,
                    });

                }
            }
            colForm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.LoadDataToDatagridAsync(DatabasePath, dataGridView1, dataGridView2);
            userHeaders = new List<string>();
            templateHeaders = new List<string>();
            service.LoadHeaders(dataGridView1, userHeaders);
            service.LoadHeaders(dataGridView2, templateHeaders);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "excel.exe",
                Arguments = $"/e \"{DatabasePath}\"",
                UseShellExecute = true
            };

            System.Diagnostics.Process.Start(processInfo);
        }


        private async void sendBackFromOutlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeProcess("");

            _logger.Info("Copying templates from Outlook: Start. *****");

            if (!CheckDirectoriesExist())
            {
                FinalizeProcess("Process stoped. Directory not found.");
                return;
            }

            var tempBackup = Path.Combine(BackupPath, _userName + "SignTemp");
            if (!Directory.Exists(tempBackup))
            {
                ShowWarning("Send your templates to edit in Outlook first.");
                _logger.Error("Temporary backup directory not found.");
                FinalizeProcess("Temporary backup directory not found.");
                return;
            }
            var tempBackupInfo = new DirectoryInfo(tempBackup);
            if (tempBackupInfo.GetFiles().Length == 0)
            {
                ShowWarning("Send your templates to edit in Outlook first.");
                _logger.Error("Send your templates to edit in Outlook first.");
                FinalizeProcess("Send your templates to edit in Outlook first.");
                return;
            }

            if (!Directory.Exists(TemplatePath))
            {
                ShowWarning("Templates directory not found.");
                _logger.Error("Templates directory not found.");
                FinalizeProcess("Templates directory not found.");
                return;
            }

            var mb = new MyMessageBoxYesNo("Do you want to send template(s) back from Outlook?", "Warning!");
            mb.ShowDialog();

            if (mb.DialogResult == DialogResult.OK)
            {
                InitializeProcess("Copying template(s) from Outlook. Please wait.");
                _logger.Info("Copying templates from Outlook.");
                await SendBackTemplatesAsync();
                InitializeProcess("Copying template(s) complete.");
                Directory.Delete(AppDataPath, true);
                Directory.CreateDirectory(AppDataPath);
                _logger.Info("Copying original signatures back to Outlook.");
                InitializeProcess("Copying original signatures back to Outlook.");
                await service.CopyDirectoryAsync(tempBackup, AppDataPath, true);
            }
            FinalizeProcess("Copying templates from Outlook complete.");
            Directory.Delete(tempBackup, true);
            _logger.Info("Copying templates from Outlook: End.");
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // send templates to outlook and backup signatures from outlook same time.

        private async void sendToOutlookStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeProcess("");
            _logger.Info("Copying templates to Outlook: Start. *****");
            if (!CheckDirectoriesExist())
            {
                FinalizeProcess("Process stoped. Directory not found.");
                return;
            }
            var tempBackup = Path.Combine(BackupPath, _userName + "SignTemp");
            var tempBackupInfo = new DirectoryInfo(tempBackup);
            MyMessageBoxYesNo mbAttention = new MyMessageBoxYesNo("Attention, you want to resend templates for editing. Your own signatures will be lost. Do you want to continue?", "Information.");
            if (Directory.Exists(tempBackup) && tempBackupInfo.GetDirectories().Length != 0)
            {
                mbAttention.ShowDialog();
                if (mbAttention.DialogResult != DialogResult.OK)
                {
                    FinalizeProcess("Process stoped.");
                    return;
                }
            }

            if (Directory.Exists(tempBackup))
            {
                Directory.Delete(tempBackup, true);
            }

            Directory.CreateDirectory(tempBackup);

            selectedTemplates = new List<DataGridViewRow>();
            var dir = new DirectoryInfo(TemplatePath);
            MyMessageBoxYesNo mbAll = new MyMessageBoxYesNo("Do you want to send ALL templates to EDIT in Outlook?", "Information");
            MyMessageBoxYesNo mbSel = new MyMessageBoxYesNo("Do you want to send SELECTED templates to EDIT in Outlook?", "Information");
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!chbGenSelTemp.Checked)
            {
                mbAll.ShowDialog();
            }
            else
            {
                mbSel.ShowDialog();
            }

            if (chbGenSelTemp.Checked && mbSel.DialogResult == DialogResult.OK)
            {
                InitializeProcess("Copying original signatures to temporary directory.");
                await CopyOriginalSignaturesFromOutlookAsync();
                
                selectedTemplates = new List<DataGridViewRow>();
                service.GetSelectedTemplateRow(selectedTemplates, this.dataGridView2);
                var pbForm1Value = 0;
                pbForm1.Maximum = dirs.Length;
                InitializeProcess("Copying templates to Outlook. Please wait.");
                foreach (DirectoryInfo subDir in dirs)
                {
                    pbForm1Value++;
                    pbForm1.Value = pbForm1Value;
                    _logger.Info($"Copying {subDir.Name}: Start.");
                    foreach (DataGridViewRow r in selectedTemplates)
                    {
                        if (r.Cells[0].Value.ToString() == subDir.Name)
                        {
                            await service.CopyDirectoryAsync(subDir.FullName, AppDataPath, true);
                        }
                    }
                    _logger.Info($"Copying {subDir.Name}: End.");
                }
                MessageBox.Show("Your template(s) have been copied to Outlook.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label1.Text = "The templates were sent to edit in Outlook.";
            }
            else if (!chbGenSelTemp.Checked && mbAll.DialogResult == DialogResult.OK)
            {
                pbForm1.Maximum = dirs.Length;
                var pbForm1Value = 0;
                InitializeProcess("Copying original signatures to temporary directory.");
                await CopyOriginalSignaturesFromOutlookAsync();

                InitializeProcess("Copying template(s) to Outlook. Please wait.");
                foreach (DirectoryInfo subDir in dirs)
                {
                    pbForm1Value++;
                    pbForm1.Value = pbForm1Value;
                    _logger.Info($"Copying {subDir.Name}: Start.");
                    await service.CopyDirectoryAsync(subDir.FullName, AppDataPath, true);
                    _logger.Info($"Copying {subDir.Name}: End.");
                }
                MessageBox.Show("Your template(s) have been copied to Outlook.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label1.Text = "The templates were sent to edit in Outlook.";
            }
            FinalizeProcess("Copying templates to Outlook complete.");
            _logger.Info("Copying templates to Outlook: End.");
        }


        private async Task CopyOriginalSignaturesFromOutlookAsync()
        {
            
            _logger.Info("Copying original Signatures from Outlook to temporary directory.");
            try
            {
                await SendSignaturesToBackupAsync();
            }
            catch (Exception ex)
            {
                _logger.Error("Copying failed." + ex.Message);
                FinalizeProcess("Copying failed. Show log file.");
                return;
            }

            label1.Text = "";
        }

        private bool CheckDirectoriesExist()
        {
            if (!Directory.Exists(TemplatePath) || !Directory.Exists(BackupPath) || !File.Exists(DatabasePath))
            {
                _logger.Error($"Source directory does not exist.");
                MessageBox.Show("Folders not found. Go to Settings and set up folders correctly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void tsmLogs_Click(object sender, EventArgs e)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(AppContext.BaseDirectory + "\\" + "Logs");
            var latestFile = dirInfo.GetFiles()
                .OrderByDescending(f => f.CreationTime)
                .FirstOrDefault().ToString();
            try
            {
                // Otevøení URL v výchozím webovém prohlížeèi
                Process.Start(new ProcessStartInfo
                {
                    FileName = latestFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Zpracování výjimky, pokud se nìco pokazí
                MessageBox.Show($"Nelze otevøít odkaz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsmAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
