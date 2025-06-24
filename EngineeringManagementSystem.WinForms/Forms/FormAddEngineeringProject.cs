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
    public partial class FormAddEngineeringProject : Form
    {
        private List<UserDTO> _users;

        public FormAddEngineeringProject()
        {
            InitializeComponent();
           
        }

        private async void FormAddEngineeringProject_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
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

            var project = new EngineeringProject
            {
                ProjectName = txtProjectName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                ProjectManagerId = selectedUser.UserId
            };

            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("https://localhost:7251/api/EngineeringProjects", project);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("הפרויקט נוסף בהצלחה.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בהוספת הפרויקט.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProjectManager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
