// ✅ מחלקה: AnswerDTO
// מייצגת תשובה שמתקבלת מהשרת (כולל מידע למי ענה ומתי)
using System;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int AnsweredByUserId { get; set; }
        public DateTime AnsweredAt   { get; set; }
    }
}