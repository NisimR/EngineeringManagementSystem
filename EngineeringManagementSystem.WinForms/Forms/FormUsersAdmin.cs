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
    public partial class FormUsersAdmin : Form
    {


        public FormUsersAdmin()
        {
            InitializeComponent();

            //btnAddUser.Click += btnAddUser_Click;
            //btnEditUser.Click += btnEditUser_Click;
            //btnDeleteUser.Click += btnDeleteUser_Click;
            //btnBack.Click += btnBack_Click;

            LoadUsers(); 
        }

        private void FormUsersAdmin_Load(object sender, EventArgs e)
        {

        }

        private async Task LoadUsers()

        {
            try
            {
                using (var client = new HttpClient())
                {
                    var users = await client.GetFromJsonAsync<List<UserDTO>>("https://localhost:7251/api/Users");
                    dataGridUsers.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת משתמשים: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
           
            new FormAddUser().ShowDialog();
            LoadUsers();
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count == 0)
                return;

            var user = (UserDTO)dataGridUsers.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show("האם אתה בטוח שברצונך למחוק את המשתמש?",
                                          "אישור מחיקה",
                                          MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (var client = new HttpClient())
            {
                var res = await client.DeleteAsync($"https://localhost:7251/api/Users/{user.UserId}");

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("המשתמש נמחק.");
                    await LoadUsers(); // ⬅️ אל תשכח להוסיף await אם LoadUsers היא async
                }
                else
                {
                    MessageBox.Show("שגיאה במחיקה.");
                }
            }
        }


        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count == 0)
                return;

            var user = (UserDTO)dataGridUsers.SelectedRows[0].DataBoundItem;
            //new FormAddOrEditUser(user).ShowDialog();
            new FormEditUser(user).ShowDialog();
            LoadUsers();
        }
    }
}
    