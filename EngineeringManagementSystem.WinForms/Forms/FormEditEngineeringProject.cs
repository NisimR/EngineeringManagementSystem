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
    public partial class FormEditEngineeringProject : Form
    {
        private EngineeringProject _project;
        private List<UserDTO> _users;

        public FormEditEngineeringProject(EngineeringProject project)
        {
            InitializeComponent();
            _project = project;
        }

        private async void FormEditEngineeringProject_Load(object sender, EventArgs e)
        {
            txtProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;

            await LoadUsersAsync();

            var selected = _users.FirstOrDefault(u => u.UserId == _project.ProjectManagerId);
            if (selected != null)
                cmbProjectManager.SelectedItem = selected;
        }

        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                _users = await client.GetFromJsonAsync<List<UserDTO>>("https://localhost:7251/api/Users");

                cmbProjectManager.DataSource = _users;
                cmbProjectManager.DisplayMember = "FullName";
                cmbProjectManager.ValueMember = "UserId";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var selectedUser = cmbProjectManager.SelectedItem as UserDTO;
            if (selectedUser == null)
            {
                MessageBox.Show("יש לבחור מנהל פרויקט.");
                return;
            }

            _project.ProjectName = txtProjectName.Text.Trim();
            _project.Description = txtDescription.Text.Trim();
            _project.ProjectManagerId = selectedUser.UserId;

            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync($"https://localhost:7251/api/EngineeringProjects/{_project.EngProjId}", _project);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("הפרויקט עודכן בהצלחה.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בעדכון הפרויקט.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
