// ✅ מחלקה: AnswerRequest
// משמשת לשליחת תשובה חדשה לשאלה
namespace EngineeringManagementSystem.WinForms.Models
{
    public class AnswerRequest
    {
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int AnsweredBy { get; set; }
    }
}