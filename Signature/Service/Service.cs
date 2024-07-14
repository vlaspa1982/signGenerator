using ExcelDataReader;
using NLog;
using System.Data;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Signature
{
    public class Service

    {
        public static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private string _username = Environment.UserName;
        public bool ErrorExist { get; set; }
        // načtení skupin pro uživatele
        public List<DataGridViewRow> GetTemplatesOfGroup(DataGridView view1, DataGridView view2, DataGridViewRow row)
        {
            // vypis jednotlivych skupin uzivatele
            string content = row.Cells[view1.Columns["group"].Index].Value.ToString();
            string[] parts = content.Split(';');
            List<string> groups = new List<string>(parts);
            List<DataGridViewRow> templates = new List<DataGridViewRow>();

            string loginName = row.Cells[0].Value.ToString();
            // vypis sablon nad ramec group

            foreach (DataGridViewRow r in view2.Rows)
            {
                Regex vyraz = new Regex($@"(?:^|[^a-zA-Z0-9_]){loginName}(?:$|[^a-zA-Z0-9_])");

                if (vyraz.IsMatch(r.Cells["login"].Value.ToString()))
                {
                    templates.Add(r);
                }
            }
            foreach (DataGridViewRow r in view2.Rows)
            {
                foreach (string g in groups)
                {
                    if (g == r.Cells[1].Value.ToString())
                    {
                        templates.Add(r);
                    }
                }
            }
            return templates;
        }
        public void GetSelectedUserRow(List<DataGridViewRow> users, DataGridView dataGridView1)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                users.Add(r);
            }
        }
        //načtení xls po zmáčknutí tlačítka uložit settings
        public async Task LoadDataToDatagridAsync(string databasePath, DataGridView view1, DataGridView view2 = null)
        {
            DataSet data = new DataSet();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            try
            {
                using (var stream = File.Open(databasePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var con = new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        };
                        data = reader.AsDataSet(con);

                        if (data.Tables.Count > 0)
                        {
                            view1.DataSource = data.Tables[0];
                        }
                        else
                        {
                            _logger.Error("Table in dataset not found.");
                        }

                        if (view2 != null && data.Tables.Count > 1)
                        {
                            view2.DataSource = data.Tables[1];
                        }
                        else if (view2 != null)
                        {
                            _logger.Error("Tabulka 1 nebyla nalezena v datasetu.");
                        }
                    }
                }
                _logger.Info($"Database: OPEN.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("Go to settings and set up your folders.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (IOException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("Close your database and try it again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("Access to the file was denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("A null reference error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadShowColumnsFromJson(view1);


        }

        private void loadShowColumnsFromJson(DataGridView view)
        {
            try
            {
                var filePath = Path.Combine(Application.UserAppDataPath, "showColumns.json");

                if (!File.Exists(filePath))
                {
                    return;
                }

                string jsonString = File.ReadAllText(filePath);

                List<ShowColumns> showColumns = JsonSerializer.Deserialize<List<ShowColumns>>(jsonString);
                var numberOfFalse = 0;
                foreach (var col in showColumns)
                {
                    if (col.ColVisible == false)
                    {
                        numberOfFalse++;
                        view.Columns[col.ColName].Visible = false;
                    }
                }
                if (numberOfFalse >= showColumns.Count)
                {
                    view.Columns[0].Visible = true;
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("The file showColumns.json was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("An error occurred during JSON deserialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("An error occurred while reading the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("Access to the file was denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("A null reference error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // change all selected templates
        public async Task ChangeTemplatesTextAsync(DataGridViewRow userRow, string pathWithSuffix, List<string> userHeaders)
        {
            try
            {
                // Asynchronní čtení souboru
                string content;
                using (StreamReader reader = new StreamReader(pathWithSuffix, Encoding.GetEncoding("Windows-1250")))
                {
                    content = await reader.ReadToEndAsync();
                }

                bool isInDatabase;

                // Kontrola shod v textu šablony
                MatchCollection contentMatches = Regex.Matches(content, @"\[%\w+[-]?\w*%\]");
                foreach (Match m in contentMatches)
                {
                    isInDatabase = false;
                    string subString = m.Value;
                    string subStringChanged = Regex.Replace(subString, @"\[%\s*|\s*%\]", "");

                    for (int i = 0; i < userHeaders.Count; i++)
                    {
                        if (userHeaders[i] == subStringChanged)
                        {
                            isInDatabase = true;
                            try
                            {
                                content = Regex.Replace(content, @"\[%" + subStringChanged + @"%\]", userRow.Cells[i].Value.ToString());
                            }
                            catch (Exception exception)
                            {
                                _logger.Error(exception.Message);
                                ErrorExist = true;
                            }
                        }
                    }
                    if (!isInDatabase)
                    {
                        Generator.instance.MissingSubString += m.Value.ToString() + "\n";
                    }
                }

                // Asynchronní zápis do souboru
                using (StreamWriter writer = new StreamWriter(pathWithSuffix, false, Encoding.GetEncoding("Windows-1250")))
                {
                    await writer.WriteAsync(content);
                }
            }
            catch (Exception exception)
            {
                ErrorExist = true;
                _logger.Error(exception.Message, $"File: {pathWithSuffix}.");
            }
        }

        public void AllCheckedChange(DataGridView view, CheckBox chBox, Control label)
        {
            if (chBox.Checked)
            {
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    view.Rows[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    view.Rows[i].Selected = false;
                }
            }
            label.Text = $"row(s) {view.SelectedRows.Count}/{view.Rows.Count}";
        }

        // show path in textboxes
        public void showDirectoryPath(TextBox textbox)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (folder.SelectedPath == Environment.CurrentDirectory)
                {
                    textbox.Text = "";
                    MessageBox.Show("Your selection is the same as the application folder. Please select another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textbox.Text = folder.SelectedPath;
            }
        }

        

        public void GetSelectedTemplateRow(List<DataGridViewRow> templates, DataGridView dataGridView2)
        {
            foreach (DataGridViewRow r in dataGridView2.SelectedRows)
            {
                templates.Add(r);
            }
        }
        public async Task ClearFolderAsync(string FolderName)
        {
            try
            {
                await Task.Run(async () =>
                {
                    DirectoryInfo dir = new DirectoryInfo(FolderName);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }

                    foreach (DirectoryInfo di in dir.GetDirectories())
                    {
                        await ClearFolderAsync(di.FullName); // Čekáme na dokončení rekurzivního volání ClearFolderAsync
                        di.Delete();
                    }
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Set up your files path", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public void LoadHeaders(DataGridView dataGrid, List<string> userHeaders)
        {
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                userHeaders.Add(dataGrid.Columns[i].HeaderCell.Value.ToString());
            }
        }

        //show textbox and lable according to validation result
        public void ShowIfIsValid(Control textbox, Control warning, Control result, bool validOrNot = false)
        {
            if (validOrNot)
            {
                textbox.ForeColor = Color.DarkGreen;
                textbox.BackColor = Color.White;
                warning.Visible = true;
                warning.Text = "OK";
                warning.ForeColor = Color.DarkGreen;
            }
            else
            {
                textbox.ForeColor = Color.Black;
                textbox.BackColor = Color.MistyRose;
                warning.Visible = true;
                warning.Text = "x Path is not valid!!!";
                warning.ForeColor = Color.Red;
            }
        }



        public void InitializeDataGridView(DataGridView view)
        {
            view.RowsDefaultCellStyle.BackColor = Color.FromArgb(248, 242, 218);
            view.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            view.ReadOnly = true;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                view.Columns[0].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            }
            catch (Exception)
            {

            }
        }
        public async Task CreateBackUpAsync(string backupSourceDir, string backupDestinationDir, string typeOfBackUp, ProgressBar pb, bool recursive, bool showMessageBox)
        {
            string dateTime = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            backupDestinationDir = Path.Combine(backupDestinationDir, $"{dateTime}-{typeOfBackUp}");
            var dir = new DirectoryInfo(backupSourceDir);
            if (!dir.Exists)
            {
                _logger.Error(new DirectoryNotFoundException($"Source directory not found: {dir.FullName}"));
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // ProgressBar setup
            pb.Visible = true;
            int ProgressBarSettingsMaximum = dirs.Length;
            int ProgressBarSettingsValue = 0;
            pb.Maximum = ProgressBarSettingsMaximum;
            pb.Value = ProgressBarSettingsValue;
            // ProgressBar setup

            try
            {
                Directory.CreateDirectory(backupDestinationDir);
                _logger.Info("Backup directory created.");
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return;
            }

            await Task.Run(() =>
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(backupDestinationDir, file.Name);
                    file.CopyTo(targetFilePath, true);
                }
            });

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(backupDestinationDir, subDir.Name);
                    await CopyDirectoryAsync(subDir.FullName, newDestinationDir, true);

                    ProgressBarSettingsValue++;
                    pb.Invoke((Action)(() => pb.Value = ProgressBarSettingsValue)); // Update ProgressBar on UI thread
                }
            }

            if (showMessageBox)
            {
                MessageBox.Show("Backup successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            pb.Visible = false;
        }


        public async Task CopyDirectoryAsync(string templateSourceDir, string outputDestinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(templateSourceDir);
            if (!dir.Exists)
            {
                var ex = new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
                _logger.Error(ex, "Source directory not found.");
                throw ex; // Je lepší throw než return pro kritické chyby
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            try
            {
                Directory.CreateDirectory(outputDestinationDir);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Directory creation failed.");
                throw; // Znovu throw pro kritické chyby
            }

            // Kopírování souborů
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(outputDestinationDir, file.Name);
                try
                {
                    // Kopírování souboru synchronně v rámci asynchronní metody
                    await CopyFileAsync(file, targetFilePath);
                }
                catch (Exception exception)
                {
                    _logger.Error(exception, $"File copying failed: {file.FullName} to {targetFilePath}");
                }
            }

            // Rekurzivní kopírování podadresářů
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(outputDestinationDir, subDir.Name);
                    await CopyDirectoryAsync(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        private async Task CopyFileAsync(FileInfo file, string targetFilePath)
        {
            using (FileStream sourceStream = file.OpenRead())
            {
                using (FileStream destinationStream = File.Create(targetFilePath))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }
        }
        public async Task BackUpMySignatureAsync(string backupSourceDir, string backupDestinationDir, bool recursive)
        {
            backupDestinationDir = Path.Combine(backupDestinationDir, _username + "SignTemp");
            var dir = new DirectoryInfo(backupSourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            try
            {
                Directory.Delete(backupDestinationDir, true);
                _logger.Info("Signature backup directory deleted.");
            }
            catch (Exception ex)
            {
                _logger.Error($"Delete directory {backupDestinationDir} failed." + ex.Message);
                return;
            }

            try
            {
                _logger.Info("Signature backup directory created.");
                Directory.CreateDirectory(backupDestinationDir);
            }
            catch (Exception exception)
            {
                _logger.Error("Backup directory not found. " + exception.Message);
                MessageBox.Show("Backup directory not found.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(backupDestinationDir, file.Name);
                await Task.Run(() => file.MoveTo(targetFilePath));
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(backupDestinationDir, subDir.Name);
                    await CopyDirectoryAsync(subDir.FullName, newDestinationDir, true);
                    Directory.Delete(subDir.FullName, true);
                }
            }
        }

    }
}
