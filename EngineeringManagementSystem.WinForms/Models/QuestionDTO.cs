// ✅ מחלקה: QuestionDTO
// מייצגת שאלה כפי שמתקבלת מהשרת (כולל מידע מלא)
using System;

namespace EngineeringManagementSystem.WinForms.Models
{

    

        public class QuestionDTO
        {
            public int QuestionId { get; set; }//מעביר מס מזהה של השאלה

            public string Answer { get; set; }

            public string AskedByUser { get; set; }//מעביר את שם השולח

            public int DocumentRevisionId { get; set; }//מעביר את המספר המזהה של המסמך

            public  string QuestionText { get; set; }//מעביר את הטקסט של השאלה

            public DateTime AskedAt { get; set; } //מעביר את הזמן שנאלה השאלה

            public string Status { get; set; } // מעביר את הסטאטוס של השאלה
        }

    






}