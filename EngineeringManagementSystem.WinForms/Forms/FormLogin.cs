using EngineeringManagementSystem.WinForms.Models;
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

using System.Net.Http.Json;



namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("יש להזין שם משתמש וסיסמה.");
                return;
            }

            var loginRequest = new
            {
                Username = username,
                Password = password
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                var response = await client.PostAsJsonAsync("api/Auth/login", loginRequest); // ← כאן היה חסר ;

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<UserDTO>();

                    Session.UserId = user.UserId;
                    Session.FullName = user.FullName;
                    Session.Role = user.Role;

                    MessageBox.Show($"שלום {user.FullName}!", "התחברת בהצלחה");

                    this.Hide();

                    if (Session.Role == "Admin")
                        new FormUsersAdmin().Show(); // רק אם קיים
                    else
                        new MainForm().Show(); // לכל שאר המשתמשים
                }
                else
                {
                    MessageBox.Show("שם משתמש או סיסמה שגויים.");
                }
            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
