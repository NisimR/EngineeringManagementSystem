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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
            LoadRoles();
            //btnAdd.Click += btnAdd_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {

        }

        private void LoadRoles()
        {
            cmbRole.Items.Add("Engineer");
            cmbRole.Items.Add("Production");
            cmbRole.Items.Add("ProjectManager");
            cmbRole.Items.Add("ProductionManager");
            cmbRole.Items.Add("Admin");

            cmbRole.SelectedIndex = 0; // ערך ברירת מחדל
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            btnAdd.Enabled = false;


            try
            {

                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();
                var fullName = txtFullName.Text.Trim();
                var role = cmbRole.SelectedItem?.ToString();
                var email = txtEmail.Text.Trim();
                var phone = txtPhone.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("נא למלא את כל השדות החובה.");
                    return;
                }

                // בדיקה שאין שם משתמש כזה כבר
                using (var checkClient = new HttpClient())
                {
                    var existsResponse = await checkClient.GetFromJsonAsync<bool>(
                        $"https://localhost:7251/api/Users/exists/{username}");

                    if (existsResponse) // אם true, המשתמש קיים
                    {
                        MessageBox.Show("שם משתמש כבר קיים במערכת.");
                        return;
                    }
                }


                var newUser = new UserRequest
                {
                    Username = username,
                    Password = password,
                    FullName = fullName,
                    Role = role,
                    Email = email,
                    PhoneNumber = phone
                };

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7251/api/Users", newUser);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("המשתמש נוסף בהצלחה.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("שגיאה בהוספת המשתמש.");
                    }
                }
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
