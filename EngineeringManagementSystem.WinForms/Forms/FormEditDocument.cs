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
    public partial class FormEditDocument : Form
    {
        private DocumentDTO _doc;

        public FormEditDocument(DocumentDTO doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        //טעינת משתמשים
        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                var users = await client.GetFromJsonAsync<List<UserDTO>>("https://localhost:7251/api/Users");

                cmbReviewer.DataSource = new List<UserDTO>(users);
                cmbApprover.DataSource = new List<UserDTO>(users);

                cmbReviewer.DisplayMember = cmbApprover.DisplayMember = "FullName";
                cmbReviewer.ValueMember = cmbApprover.ValueMember = "UserId";

                // הגדרת המשתמש הנוכחי כברירת מחדל
                cmbReviewer.SelectedItem = users.FirstOrDefault(u => u.FullName == _doc.Reviewer);
                cmbApprover.SelectedItem = users.FirstOrDefault(u => u.FullName == _doc.Approver);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void FormEditDocument_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();

            txtDocName.Text = _doc.DocName;
            txtPathDoc.Text = _doc.PathDoc;
            lblRevision.Text = $"מהדורה: {_doc.Rev}";

            if (_doc.IsReleased)
            {
                MessageBox.Show("המסמך משוחרר. תתבצע יצירת מהדורה חדשה.");
                this.Close();

                var formNewRev = new FormCreateNewRevision(_doc);
                formNewRev.ShowDialog();
            }
        }


        private void txtDocName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPathDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbReviewer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbApprover_SelectedIndexChanged(object sender, EventArgs e)
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new DocumentRequest
            {
                DocName = txtDocName.Text,
                PathDoc = txtPathDoc.Text,
                ReviewerName = ((UserDTO)cmbReviewer.SelectedItem)?.FullName,
                ApproverName = ((UserDTO)cmbApprover.SelectedItem)?.FullName,
                AuthorName = _doc.Author,
                EngProjId = _doc.EngProjId
            };

            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync($"https://localhost:7251/api/Documents/{_doc.DocumentId}", request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("המסמך עודכן בהצלחה.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("שגיאה בעדכון המסמך.");
                }
            }
        }

    }
}
