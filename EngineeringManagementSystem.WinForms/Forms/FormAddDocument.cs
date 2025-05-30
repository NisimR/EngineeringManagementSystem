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
    public partial class FormAddDocument : Form
    {
        private readonly int _projectId; // מזהה הפרויקט שאליו שייך המסמך

        public FormAddDocument(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
        }

        // בעת טעינת הטופס נטען את המשתמשים ונציג את מזהה הפרויקט
        private async void FormAddDocument_Load(object sender, EventArgs e)
        {
            lblProjectName.Text = $"העלאת מסמך חדש לפרויקט מספר {_projectId}";
            await LoadUsersAsync();
        }

        // טעינת רשימת המשתמשים מתוך ה־API ושיוכם ל־ComboBoxים
        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                var users = await client.GetFromJsonAsync<List<UserDTO>>("https://localhost:7251/api/Users");

                // שיבוץ לכל combo
                cmbAuthor.DataSource = new List<UserDTO>(users);
                cmbReviewer.DataSource = new List<UserDTO>(users);
                cmbApprover.DataSource = new List<UserDTO>(users);

                // מגדירים מה יוצג ומה יישמר כ־value
                cmbAuthor.DisplayMember = cmbReviewer.DisplayMember = cmbApprover.DisplayMember = "FullName";
                cmbAuthor.ValueMember = cmbReviewer.ValueMember = cmbApprover.ValueMember = "UserId";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtPathDoc.Text = dlg.FileName;
                }
            }
        }

        // שליחת הבקשה לשרת – יצירת המסמך בפועל
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // בניית הבקשה לפי מחלקת DocumentRequest
            var request = new DocumentRequest
            {
                PartNumberDoc = _projectId,
                DocName = txtDocName.Text,
                PathDoc = txtPathDoc.Text,
                AuthorName = ((UserDTO)cmbAuthor.SelectedItem).FullName,
                ReviewerName = ((UserDTO)cmbReviewer.SelectedItem).FullName,
                ApproverName = ((UserDTO)cmbApprover.SelectedItem).FullName
            };

            using (var client = new HttpClient())
            {
                // שליחת המסמך ל־API
                var response = await client.PostAsJsonAsync("https://localhost:7251/api/Documents", request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("המסמך נוסף בהצלחה!");
                    this.Close(); // סוגר את הטופס לאחר הצלחה
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בהוספת המסמך.");
                }
            }
        }
    }
}
