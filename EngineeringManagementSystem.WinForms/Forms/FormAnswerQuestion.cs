using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;



namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormAnswerQuestion : Form
    {
        private readonly int _questionId;
        private readonly string _questionText;
        private readonly int _answeredByUserId;
        public FormAnswerQuestion(int questionId, string questionText, int answeredByUserId)
        {
            InitializeComponent();
            _questionId = questionId;
            _questionText = questionText;
            _answeredByUserId = answeredByUserId;
            lblQuestion.Text = _questionText;
        }

        private void FormAnswerQuestion_Load(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("נא להזין תשובה.");
                return;
            }

            var answerDto = new AnswerDTO
            {
                QuestionId = _questionId,
                AnswerText = txtAnswer.Text,
                AnsweredByUserId = _answeredByUserId,
                AnsweredAt = DateTime.Now
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251/");
                var response = await client.PostAsJsonAsync("api/Answers", answerDto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("התשובה נשלחה בהצלחה.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("שגיאה בשליחת התשובה.");
                }
            }
        }
    }
}
