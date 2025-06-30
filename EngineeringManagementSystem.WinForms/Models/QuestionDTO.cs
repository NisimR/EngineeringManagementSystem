// ✅ מחלקה: QuestionDTO
// מייצגת שאלה כפי שמתקבלת מהשרת (כולל מידע מלא)
using System;

namespace EngineeringManagementSystem.WinForms.Models
{



    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int DocumentId { get; set; }

        public int AskedByUserId { get; set; }
        public string AskedByUserName { get; set; } // 🟢

        public DateTime AskedAt { get; set; }

        public string Status { get; set; }
        public int? AnswerId { get; set; }

        public string AnsweredByUserName { get; set; } // 🟢


    }








}