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
using System.IO;
using EngineeringManagementSystem.WinForms.Forms;
using System.Linq.Expressions;
using System.Diagnostics;



namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormEngineering : Form
    {

        private async void FormEngineering_Load(object sender, EventArgs e)
        {
            await LoadProjectsAsync();
            await LoadPendingDocumentsForUser();

            this.Controls.Add(dataGridPendingDocs);
            this.Controls.Add(btnApprove);
            this.Controls.Add(btnReject);
            this.Controls.Add(btnOpen);

            btnApprove.Click += btnApprove_Click;
            btnReject.Click += btnReject_Click;
            btnOpen.Click += btnOpen_Click;

        }

        private async Task LoadProjectsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");

                // ⬅️ כאן חשוב מאוד להוסיף את הנתיב ל-API
                var projects = await client.GetFromJsonAsync<List<EngineeringProject>>("api/EngineeringProjects");

                cmbProjects.DataSource = projects;
                cmbProjects.DisplayMember = "ProjectName";
                cmbProjects.ValueMember = "EngProjId";
            }
        }

        public FormEngineering()
        {
            InitializeComponent();
        }

        private async Task LoadPendingDocumentsForUser()
        {
            var client = new HttpClient();
            var userId = Session.UserId;
            var result = await client.GetFromJsonAsync<List<DocumentDTO>>($"https://localhost:7251/api/Documents/pendingForUser/{userId}");
            dataGridPendingDocs.DataSource = result;
            client.Dispose();
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }

        private async void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectId)
            {
                await LoadDocumentsForProject(projectId);        // טוען מסמכים לפרויקט
                await LoadQuestionsForProject(projectId);        // טוען שאלות כלליות לפרויקט

            }


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// טוען מסמכים הקשורים לפרויקט.
        /// </summary>
        private async Task LoadDocumentsForProject(int projectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                var docs = await client.GetFromJsonAsync<List<DocumentDTO>>($"api/Documents/byProject/{projectId}");
                dataGridDocuments.DataSource = docs;
            }
        }

        /// <summary>
        /// טוען שאלות הקשורות לפרויקט.
        /// </summary>
        private async Task LoadQuestionsForProject(int projectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                try
                {
                    // פונה לשרת ומבקש את השאלות על הפרויקט
                    var questions = await client.GetFromJsonAsync<List<QuestionDTO>>($"api/Questions/byProject/{projectId}");
                    dataGridQuestions.DataSource = questions;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"שגיאה בטעינת שאלות: {ex.Message}");
                }
            }
        }


        private async void FormEngineering_Load_1(object sender, EventArgs e)
        {
            dataGridDocuments.SelectionChanged += dataGridDocuments_SelectionChanged;
            await LoadProjectsAsync();
        }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
            {
                MessageBox.Show("בחר מסמך לפתיחה.");
                return;
            }

            var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            if (!string.IsNullOrEmpty(doc.PathDoc) && File.Exists(doc.PathDoc))
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = doc.PathDoc,
                    UseShellExecute = true,
                    Verb = doc.IsReleased ? "open" : "edit"
                };
                process.Start();
            }
            else
            {
                MessageBox.Show("הקובץ לא נמצא.");
            }
        }

        private async void btnEditDoc_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
                return;

            var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            if (doc.IsReleased)
            {
                var result = MessageBox.Show(
                    "המסמך משוחרר. האם ברצונך ליצור מהדורה חדשה?",
                    "מסמך משוחרר",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // פתח מסך יצירת מהדורה חדשה
                    var createNewRevForm = new FormCreateNewRevision(doc);
                    createNewRevForm.ShowDialog();

                    // רענון המסמכים לאחר יצירת מהדורה
                    await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
                }

                return;
            }

            // אם המסמך לא משוחרר – פתח עריכה רגילה
            new FormEditDocument(doc).ShowDialog();
            await LoadDocumentsForProject((int)cmbProjects.SelectedValue); // רענון


        }

        private async void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
                return;

            var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            if (doc.IsReleased && Session.Role != "Admin")
            {
                MessageBox.Show("רק אדמין יכול למחוק מסמך משוחרר.");
                return;
            }

            var confirm = MessageBox.Show("האם אתה בטוח שברצונך למחוק?", "אישור מחיקה", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (var client = new HttpClient())
            {
                await client.DeleteAsync($"https://localhost:7251/api/Documents/{doc.DocumentId}");
                MessageBox.Show("המסמך נמחק.");
                await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
            }
        }


        private async void btnReleaseDoc_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
                return;

            var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            using (var client = new HttpClient())
            {
                // הפעולה מאשרת בשם היוזר הנוכחי שהוא ה־Author
                var response = await client.PostAsync($"https://localhost:7251/api/Documents/{doc.DocumentId}/approve/{Session.UserId}", null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("המסמך הועבר לבדיקה.");
                    await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
                    await LoadPendingDocumentsForUser(); // טוען את הגריד של החתימות מחדש
                }
                else
                {
                    MessageBox.Show("שגיאה בשחרור המסמך.");
                }
            }
        }


        /// <summary>
        /// בעת בחירת שורה במסמכים – טען שאלות על המסמך.
        /// </summary>
        private async void dataGridDocuments_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count > 0)
            {
                var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;
                await LoadQuestionsForDocument(doc.DocumentId); // ← מתייחס ל־DocumentId כעת
            }
        }
        private async void btnAddDoc_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectId)
            {
                new FormAddDocument(projectId).ShowDialog();
                await LoadDocumentsForProject(projectId); // ← ממתין לסיום טעינת המסמכים
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// טוען שאלות הקשורות למסמך.
        /// </summary>
        private async Task LoadQuestionsForDocument(int documentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                try
                {
                    // מביא שאלות לפי מזהה מסמך
                    var questions = await client.GetFromJsonAsync<List<QuestionDTO>>($"api/Questions/byDocument/{documentId}");
                    dataGridQuestions.DataSource = questions;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"שגיאה בטעינת שאלות: {ex.Message}");
                }
            }
        }

        private void dataGridQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAnswerQuestion_Click(object sender, EventArgs e)
        {
            if (dataGridQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("בחר שאלה לענות עליה.");
                return;
            }

            var question = (QuestionDTO)dataGridQuestions.SelectedRows[0].DataBoundItem;

            if (question.AnswerId != null && question.AnswerId != 0)
            {
                MessageBox.Show("שאלה זו כבר נענתה.");
                return;
            }

            var answerForm = new FormAnswerQuestion(
                questionId: question.QuestionId,
                questionText: question.QuestionText,
                answeredByUserId: 1 // 🟡 לשנות למשתמש הנוכחי המחובר
            );

            answerForm.ShowDialog();

            // רענון אחרי סגירת התשובה
            _ = LoadQuestionsForDocument(question.DocumentId);
        }

        private async void btnNewRevision_Click(object sender, EventArgs e)
        {
            if (dataGridDocuments.SelectedRows.Count == 0)
            {
                MessageBox.Show("בחר מסמך קודם.");
                return;
            }

            var selectedDoc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            if (!selectedDoc.IsReleased)
            {
                MessageBox.Show("ניתן ליצור מהדורה רק ממסמך ששוחרר.");
                return;
            }

            var doc = (DocumentDTO)dataGridDocuments.SelectedRows[0].DataBoundItem;

            if (doc.IsReleased)
            {
                var result = MessageBox.Show(
                    "המסמך משוחרר. האם ברצונך ליצור מהדורה חדשה?",
                    "מסמך משוחרר",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // פתח מסך יצירת מהדורה חדשה
                    var createNewRevForm = new FormCreateNewRevision(doc);
                    createNewRevForm.ShowDialog();

                    // רענון המסמכים לאחר יצירת מהדורה
                    await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
                }

                return;
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridPendingDocs.SelectedRows.Count == 0) return;
            var doc = (DocumentDTO)dataGridPendingDocs.SelectedRows[0].DataBoundItem;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://localhost:7251/api/Documents/{doc.DocumentId}/approve/{Session.UserId}", null);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("אושר בהצלחה");
                    await LoadPendingDocumentsForUser();
                    await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
                }
                else MessageBox.Show("שגיאה באישור");
            }
        }


        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (dataGridPendingDocs.SelectedRows.Count == 0) return;
            var doc = (DocumentDTO)dataGridPendingDocs.SelectedRows[0].DataBoundItem;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://localhost:7251/api/Documents/{doc.DocumentId}/reject/{Session.UserId}", null);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("נדחה בהצלחה");
                    await LoadPendingDocumentsForUser();
                    await LoadDocumentsForProject((int)cmbProjects.SelectedValue);
                }
                else MessageBox.Show("שגיאה בדחייה");
            }
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dataGridPendingDocs.SelectedRows.Count == 0) return;
            var doc = (DocumentDTO)dataGridPendingDocs.SelectedRows[0].DataBoundItem;
            if (File.Exists(doc.PathDoc))
                Process.Start("explorer", doc.PathDoc);
            else
                MessageBox.Show("הקובץ לא נמצא");
        }

        private void dataGridPendingDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
