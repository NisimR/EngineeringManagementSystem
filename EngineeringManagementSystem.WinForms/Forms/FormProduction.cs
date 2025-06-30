using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;
using System.IO;
using EngineeringManagementSystem.WinForms.Forms;
using System.Linq.Expressions;
using System.Diagnostics;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormProduction : Form
    {
        public FormProduction()
        {
            InitializeComponent();
        }

        private async void FormProduction_Load(object sender, EventArgs e)
        {
            dgvProjects.SelectionChanged += dgvProjects_SelectionChanged;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            using (var client = new HttpClient())
            {
                var projects = await client.GetFromJsonAsync<List<ProductionProject>>("https://localhost:7251/api/ProductionProjects");
                dgvProjects.DataSource = projects;
            }
        }

        private async void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                var projectId = (int)dgvProjects.SelectedRows[0].Cells["ProdProjId"].Value;
                await LoadItemsAsync(projectId);
                await LoadQuestionsForProjectAsync(projectId);
            }
        }

        private async Task LoadItemsAsync(int projectId)
        {
            using (var client = new HttpClient())
            {
                var items = await client.GetFromJsonAsync<List<ProductionItem>>($"https://localhost:7251/api/ProductionItems/byProject/{projectId}");
                dgvItems.DataSource = items;
            }
        }

        private async Task LoadQuestionsForProjectAsync(int projectId)
        {
            using (var client = new HttpClient())
            {
                var questions = await client.GetFromJsonAsync<List<QuestionDTO>>($"https://localhost:7251/api/Questions/byProject/{projectId}");
                dgvQuestions.DataSource = questions;

                
            }
        }

        private async void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var docId = (int)dgvItems.SelectedRows[0].Cells["DocumentId"].Value;
                await LoadQuestionsForDocumentAsync(docId);
            }
        }

        private async Task LoadQuestionsForDocumentAsync(int documentId)
        {
            using (var client = new HttpClient())
            {
                var questions = await client.GetFromJsonAsync<List<QuestionDTO>>($"https://localhost:7251/api/Questions/byDocument/{documentId}");
                dgvQuestions.DataSource = questions;
            }
        }
        private async void btnOpenDoc_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("בחר פריט עם מסמך");
                return;
            }

            var docId = (int)dgvItems.SelectedRows[0].Cells["DocumentId"].Value;

            using (var client = new HttpClient())
            {
                var doc = await client.GetFromJsonAsync<DocumentDTO>($"https://localhost:7251/api/Documents/{docId}");
                if (!string.IsNullOrEmpty(doc.PathDoc) && File.Exists(doc.PathDoc))
                {
                    Process.Start("explorer", doc.PathDoc);
                }
                else
                {
                    MessageBox.Show("הקובץ לא נמצא");
                }
            }
        }

        private void btnAskQuestion_Click(object sender, EventArgs e)
        {
            int? projectId = null;
            int? documentId = null;

            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("בחר מסמך.");
                return;
            }


            if (dgvItems.SelectedRows.Count > 0)
                documentId = (int)dgvItems.SelectedRows[0].Cells["DocumentId"].Value;

            var form = new FormAskQuestion(documentId);
            form.ShowDialog();

            // לאחר הוספת שאלה – רענון
            if (documentId != null)
                _ = LoadQuestionsForDocumentAsync(documentId.Value);
            else if (projectId != null)
                _ = LoadQuestionsForProjectAsync(projectId.Value);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
