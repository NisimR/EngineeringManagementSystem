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

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormEngineering : Form
    {

        private async void FormEngineering_Load(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                var projects = await client.GetFromJsonAsync<List<EngineeringProjectDTO>>("api/EngineeringProjects");
                cmbProjects.DataSource = projects;
                cmbProjects.DisplayMember = "ProjectName";  // או השדה שאתה מציג
                cmbProjects.ValueMember = "ProjectId";
            }
        }

        public FormEngineering()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private async void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectId)
            {
                await LoadDocumentsForProject(projectId);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task LoadDocumentsForProject(int projectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                var docs = await client.GetFromJsonAsync<List<DocumentDTO>>($"api/Documents/byProject/{projectId}");
                dataGridDocuments.DataSource = docs;
            }
        }

        private void FormEngineering_Load_1(object sender, EventArgs e)
        {

        }
    }
}
