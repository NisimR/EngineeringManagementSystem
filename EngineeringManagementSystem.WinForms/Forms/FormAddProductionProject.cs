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
    public partial class FormAddProductionProject : Form
    {
        public FormAddProductionProject()
        {
            InitializeComponent();
        }

        private async void FormAddProductionProject_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();

        }

        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251");
                var response = await client.GetAsync("/api/Users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UserDTO>>(json);

                    cboManagers.DataSource = users;
                    cboManagers.DisplayMember = "FullName"; // שנה אם צריך
                    cboManagers.ValueMember = "UserId";
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בעת טעינת המשתמשים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) ||
    string.IsNullOrWhiteSpace(txtDescription.Text) ||
    cboManagers.SelectedItem == null)
            {
                MessageBox.Show("אנא מלא את כל השדות", "שדות חסרים", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newProject = new ProductionProject
            {
                ProjectName = txtProjectName.Text,
                Description = txtDescription.Text,
                ProjectManagerId = (int)cboManagers.SelectedValue,
                CreatedAt = DateTime.Now,
                ProductionItem = new List<int>()
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251");
                var res = await client.PostAsJsonAsync("/api/ProductionProjects", newProject);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("הפרויקט נוסף בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בשמירת הפרויקט", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
