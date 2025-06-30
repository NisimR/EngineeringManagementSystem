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
    public partial class FormAskQuestion : Form
    {
        private int _documentId;
        public FormAskQuestion(int? documentId)
        {
            InitializeComponent();
            _documentId = (int)documentId;
        }

        private void FormAskQuestion_Load(object sender, EventArgs e)
        {

        }

        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string questionText = txtQuestion.Text.Trim();

            if (string.IsNullOrWhiteSpace(questionText))
            {
                MessageBox.Show("נא לכתוב את השאלה");
                return;
            }

            

            var dto = new QuestionDTO
            {
                QuestionText = questionText,
                DocumentId = _documentId,
                AskedByUserId = Session.UserId
            };

            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("https://localhost:7251/api/Questions", dto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("השאלה נשלחה בהצלחה");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בשליחת השאלה");
                }
            }
        }
    }
}
