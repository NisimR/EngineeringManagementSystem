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
    public partial class FormEditUser : Form
    {
        private readonly int _userId;

        public FormEditUser(UserDTO user)
        {
            InitializeComponent();

            _userId = user.UserId;

            txtUsername.Text = user.UserName;
            txtUsername.ReadOnly = true;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.PhoneNumber;
            LoadRoles();
            cmbRole.SelectedItem = user.Role;
        }

        private void LoadRoles()
        {
            cmbRole.Items.AddRange(new[] { "Engineer", "Production", "ProjectManager", "ProductionManager", "Admin" });
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {

        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;

            var updatedUser = new UserRequest
            {
                Username = txtUsername.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Role = cmbRole.SelectedItem?.ToString(),
                Password = txtNewPassword.Text.Trim() // ריק אם לא שונה
            };

            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync($"https://localhost:7251/api/Users/{_userId}", updatedUser);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("המשתמש עודכן בהצלחה.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בעדכון המשתמש.");
                }
            }

            btnSaveChanges.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
