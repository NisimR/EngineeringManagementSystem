using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormAddDocument : Form
    {
        private readonly int _projectId;

        public FormAddDocument(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
        }

        private async void FormAddDocument_Load(object sender, EventArgs e)
        {
            lblProjectName.Text = $"העלאת מסמך חדש לפרויקט מספר {_projectId}";

            // ✅ קובע את השם של המחבר הנוכחי
            lblAuthor.Text = Session.FullName;

            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                var users = await client.GetFromJsonAsync<List<UserDTO>>("https://localhost:7251/api/Users");

                // ✅ טוען רק לרשימות של Reviewer ו־Approver
                cmbReviewer.DataSource = new List<UserDTO>(users);
                cmbApprover.DataSource = new List<UserDTO>(users);

                cmbReviewer.DisplayMember = cmbApprover.DisplayMember = "FullName";
                cmbReviewer.ValueMember = cmbApprover.ValueMember = "UserId";
            }
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // ✅ בונה את הבקשה עם שם מחבר מה־Session
            var request = new DocumentRequest
            {
                //PartNumberDoc = 0,
                DocName = txtDocName.Text,
                PathDoc = txtPathDoc.Text,
                AuthorName = Session.FullName, // ← שם המחבר מתוך ה־Session
                ReviewerName = (cmbReviewer.SelectedItem as UserDTO)?.FullName,
                ApproverName = (cmbApprover.SelectedItem as UserDTO)?.FullName,
                EngProjId = _projectId
            };

            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("https://localhost:7251/api/Documents", request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("המסמך נוסף בהצלחה!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בהוספת המסמך.");
                }
            }
        }
    }
}
