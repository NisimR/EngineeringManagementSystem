using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormCreateNewRevision : Form
    {
        private readonly DocumentDTO _oldDoc;

        public FormCreateNewRevision(DocumentDTO oldDoc)
        {
            InitializeComponent();
            _oldDoc = oldDoc;

            txtOldName.Text = oldDoc.DocName;
            txtOldRev.Text = oldDoc.Rev;
            txtNewRev.Text = GetNextRevision(oldDoc.Rev);
        }

        private string GetNextRevision(string currentRev)
        {
            if (string.IsNullOrEmpty(currentRev)) return "A";
            char revChar = currentRev[0];
            return ((char)(revChar + 1)).ToString();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var newRev = txtNewRev.Text;

                var newDoc = new DocumentRequest
                {
                    PartNumberDoc = _oldDoc.PartNumberDoc,
                    DocName = _oldDoc.DocName,
                    PathDoc = GetCopiedFilePath(_oldDoc.PathDoc),
                    AuthorName = _oldDoc.Author,
                    ReviewerName = _oldDoc.Reviewer,
                    ApproverName = _oldDoc.Approver,
                    EngProjId = _oldDoc.EngProjId
                };

                var client = new HttpClient { BaseAddress = new Uri("https://localhost:7251/") };

                // ✅ שימוש ב־createNewRevision ולא ב־POST רגיל כדי לקבל מהדורה חדשה
                var response = await client.PostAsJsonAsync($"api/Documents/{_oldDoc.DocumentId}/createNewRevision", newDoc);

                if (!response.IsSuccessStatusCode)
                {
                    // ✅ שיפור הצגת שגיאה עם הודעת שרת
                    var errText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("שגיאה ביצירת המסמך החדש:\n" + errText);
                    return;
                }

                // ✅ העתקת הקובץ המקומי מתבצעת כבר בשרת – לא חובה כאן
                // אבל נבצע אותה גם מקומית לצורך סנכרון
                File.Copy(_oldDoc.PathDoc, newDoc.PathDoc, overwrite: true);

                MessageBox.Show("מהדורה חדשה נוצרה בהצלחה.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}");
            }
        }

        private string GetCopiedFilePath(string originalPath)
        {
            // ✅ כאן נבנה את שם הקובץ החדש בצורה זמנית (השרת גם בונה שם סופי)
            string dir = Path.GetDirectoryName(originalPath);
            string newFileName = Guid.NewGuid().ToString() + ".docx";
            return Path.Combine(dir, newFileName);
        }

        private void FormCreateNewRevision_Load(object sender, EventArgs e)
        {
            // לא דרוש תוכן
        }
    }
}
