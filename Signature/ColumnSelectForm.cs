using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signature
{
    public partial class ColumnSelectForm : Form
    {
        Service service = new Service();
        FindControl fc = new FindControl();
        public static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        DataGridView dataGridView1 = new DataGridView();
        public ColumnSelectForm()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
        }

        private void ColumnSelectForm_Load(object sender, EventArgs e)
        {
            //zobrazeni jen vybraných sloupců

            dataGridView1 = (DataGridView)fc.Ctrl(Generator.instance, "dataGridView1");
            List<string> headers = new List<string>();
            service.LoadHeaders(dataGridView1, headers);

            foreach (ShowColumns col in Generator.instance.ShowColumns)
            {
                if (col.ColVisible == true)
                {
                    checkedListBox1.Items.Add(col.ColName, true);
                }
                else
                {
                    checkedListBox1.Items.Add(col.ColName, false);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<ShowColumns> ShowColumns = new List<ShowColumns>();
            foreach (var col in checkedListBox1.Items)
            {
                if (!checkedListBox1.CheckedItems.Contains(col))
                {
                    dataGridView1.Columns[col.ToString()].Visible = false;
                    ShowColumns.Add(new Signature.ShowColumns
                    {
                        ColName = col.ToString(),
                        ColVisible = false,
                    });
                }
                else
                {
                    dataGridView1.Columns[col.ToString()].Visible = true;
                    ShowColumns.Add(new Signature.ShowColumns
                    {
                        ColName = col.ToString(),
                        ColVisible = true,
                    });
                }
            }
           
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                dataGridView1.Visible = false;
            }else
            {
                dataGridView1.Visible = true;
            }
            await WriteJsonAsync(ShowColumns);
            this.Close();
        }
        private async Task WriteJsonAsync(List<ShowColumns> columns)
        {
            try
            {
                string filePath = Path.Combine(Application.UserAppDataPath, "showColumns.json");

                // Serializace kolekce do JSON
                string jsonString = JsonSerializer.Serialize(columns, new JsonSerializerOptions { WriteIndented = true });

                // Zápis JSON do souboru
                await File.WriteAllTextAsync(filePath, jsonString);

               _logger.Info("Show columns serialization to Json: OK");
            }
            catch (JsonException jsonEx)
            {
                _logger.Error("Failed to serialize show columns to JSON.", jsonEx);
                MessageBox.Show("Error while saving show columns to JSON. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                _logger.Error("Failed to write show columns JSON file.", ioEx);
                MessageBox.Show("Error while writing JSON file. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                _logger.Error("Access denied while writing show columns JSON file.", uaEx);
                MessageBox.Show("Access denied while saving settings. Please check your permissions and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.Error("An unexpected error occurred while saving show columns.", ex);
                MessageBox.Show("An unexpected error occurred while saving settings. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
           
        }
    }
}
