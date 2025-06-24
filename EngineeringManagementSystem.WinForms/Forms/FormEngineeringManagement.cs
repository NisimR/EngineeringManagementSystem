using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormEngineeringManagement : Form
    {
        private List<EngineeringProject> _projects;

        public FormEngineeringManagement()
        {
            InitializeComponent();
            //btnAddProject.Click += BtnAddProject_Click;
            //btnEditProject.Click += BtnEditProject_Click;
            dgvProjects.SelectionChanged += DataGridProjects_SelectionChanged;
        }

        private async void FormEngineeringManagement_Load(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            using (var client = new HttpClient())
            {
                _projects = await client.GetFromJsonAsync<List<EngineeringProject>>("https://localhost:7251/api/EngineeringProjects");
                dgvProjects.DataSource = _projects;
            }
        }

        private EngineeringProject GetSelectedProject()
        {
            if (dgvProjects.CurrentRow?.DataBoundItem is EngineeringProject project)
                return project;
            return null;
        }





        private async void DataGridProjects_SelectionChanged(object sender, EventArgs e)
        {
            var project = GetSelectedProject();
            if (project != null)
            {
                using (var client = new HttpClient())
                {
                    var documents = await client.GetFromJsonAsync<List<DocumentDTO>>(
                        $"https://localhost:7251/api/Documents/byProject/{project.EngProjId}");
                    dgvProjectDocuments.DataSource = documents;
                }
            }
        }
        

        private void btnAddProject_Click_1(object sender, EventArgs e)
        {
            var form = new FormAddEngineeringProject();
            if (form.ShowDialog() == DialogResult.OK)
                _ = LoadProjectsAsync();
        }

        private void btnEditProject_Click_1(object sender, EventArgs e)
        {
            var selected = GetSelectedProject();
            if (selected != null)
            {
                var form = new FormEditEngineeringProject(selected);
                if (form.ShowDialog() == DialogResult.OK)
                    _ = LoadProjectsAsync();
            }
        }

        private async void btnRefreshProjects_Click(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedProject();
            if (selected != null)
            {
                var form = new FormAddDocument(selected.EngProjId);
                if (form.ShowDialog() == DialogResult.OK)
                    DataGridProjects_SelectionChanged(null, null);
            }
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {
            if (dgvProjectDocuments.CurrentRow?.DataBoundItem is DocumentDTO doc)
            {
                var form = new FormEditDocument(doc);
                if (form.ShowDialog() == DialogResult.OK)
                    DataGridProjects_SelectionChanged(null, null);
            }
        }

        private async void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            if (dgvProjectDocuments.CurrentRow?.DataBoundItem is DocumentDTO doc)
            {
                var confirm = MessageBox.Show("האם אתה בטוח שברצונך למחוק את המסמך?", "אישור מחיקה", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var client = new HttpClient())
                    {
                        var res = await client.DeleteAsync($"https://localhost:7251/api/Documents/{doc.DocumentId}");
                        if (res.IsSuccessStatusCode)
                        {
                            MessageBox.Show("המסמך נמחק בהצלחה.");
                            DataGridProjects_SelectionChanged(null, null);
                        }
                        else
                        {
                            MessageBox.Show("אירעה שגיאה במחיקת המסמך.");
                        }
                    }
                }
            }
        }

        private void btnRefreshDocuments_Click(object sender, EventArgs e)
        {
            DataGridProjects_SelectionChanged(null, null);
        }
    }
}
