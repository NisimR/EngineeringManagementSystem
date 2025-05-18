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
using System.Net.Http.Headers;
using Newtonsoft.Json;
using EngineeringManagementSystem.WinForms.Models;
using System.Diagnostics;
namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class MainScreen : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public MainScreen()
        {
            Debug.WriteLine("בדיקה");


            InitializeComponent();
            this.Load += MainScreen_Load;


        }

        private async void MainScreen_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();

        }

        private async Task LoadUsersAsync()
        {

            Console.WriteLine("ccc");
            try
            {
                // כתובת ה-API שלך 
                //without https only http
                string apiUrl = "http://localhost:5222/api/Users";
               // System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                //response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                //// ניתוח ה-JSON לרשימת UserDTO
                //var users = JsonSerializer.Deserialize<List<UserDTO>>(json, new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //});
                var users = JsonConvert.DeserializeObject<List<UserDTO>>(json);


                userDTOBindingSource.DataSource = users;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"שגיאה: {ex.Message}\n{ex.StackTrace}");
                Debug.WriteLine($"Message here  {ex.Message}\n{ex.StackTrace}");

            }
        }

        private async void addUserBtn_Click(object sender, EventArgs e)
        {
            var newUser = new
            {
                Username = username.Text.Trim(),
                fullName = fullName.Text.Trim(),
                role = role.Text.Trim(),
                passwordHash = passwordHash.Text.Trim(),
                email = email.Text.Trim()

            };

            try
            {

                Debug.WriteLine($"Message here !!!");

                string apiUrl = "http://localhost:5222/api/users"; // ודא שזה נכון

                var json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);
                Debug.WriteLine($"Object = {json}");

                response.EnsureSuccessStatusCode();

                MessageBox.Show("משתמש נוסף בהצלחה!");
                await LoadUsersAsync(); // רענון הרשימה
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message herexxxx  {ex.Message}\n{ex.StackTrace}");

                MessageBox.Show($"שגיאה בהוספת משתמש: {ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
