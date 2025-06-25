using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;
using System.Net.Http.Json;


namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormProductionItem : Form
    {

        private int _projectId;
        private int _createdById;


        public FormProductionItem()
        {
            InitializeComponent();
        }

        public FormProductionItem(int projectId, int createdById)
        {
            InitializeComponent();
            _projectId = projectId;
            _createdById = createdById;
        }

        private async void FormProductionItem_Load(object sender, EventArgs e)
        {
            await LoadReleasedDocumentsAsync();
        }


        private List<DocumentDTO> _documents;

        private async Task LoadReleasedDocumentsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7251/api/Documents");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    _documents = JsonConvert.DeserializeObject<List<DocumentDTO>>(json)
                        .Where(d => d.IsReleased)
                        .ToList();

                    dataGridDocuments.DataSource = _documents.Select(d => new
                    {
                        d.DocumentId,
                        d.DocName,
                        d.PartNumberDoc,
                        d.Rev,
                        d.ReleaseDate
                    }).ToList();
                }
            }
        }

        private void dataGridDocuments_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count > 0)
            {
                var row = dataGridDocuments.SelectedRows[0];
                int docId = (int)row.Cells["DocumentId"].Value;
                var selectedDoc = _documents.FirstOrDefault(d => d.DocumentId == docId);

                if (selectedDoc != null)
                {
                    txtPartName.Text = selectedDoc.PartNumberDoc.ToString(); // או DocName
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
            {
                MessageBox.Show("יש לבחור מסמך מהרשימה.");
                return;
            }

            var row = dataGridDocuments.SelectedRows[0];
            int documentId = (int)row.Cells["DocumentId"].Value;

            var request = new
            {
                ProductionProjectId = _projectId,
                DocumentId = documentId,
                PartName = txtPartName.Text,
                Quantity = (int)numQuantity.Value,
                CreatedById = _createdById
            };

            using (var client = new HttpClient())
            {
                var res = await client.PostAsJsonAsync("https://localhost:7251/api/ProductionItems", request);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("הפריט נוסף בהצלחה.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("שגיאה בהוספה.");
                }
            }
        }
    }
}
