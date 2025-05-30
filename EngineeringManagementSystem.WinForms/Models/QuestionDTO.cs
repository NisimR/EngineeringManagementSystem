// ✅ מחלקה: QuestionDTO
// מייצגת שאלה כפי שמתקבלת מהשרת (כולל מידע מלא)
using System;

namespace EngineeringManagementSystem.WinForms.Models
{

    

        public class QuestionDTO
        {


        public int QuestionId { get; set; }            // מזהה ייחודי של השאלה
        public string QuestionText { get; set; }       // תוכן השאלה
        public int DocumentId { get; set; }            // מזהה המסמך
        public int AskedByUserId { get; set; }         // מזהה המשתמש ששאל
        public DateTime AskedAt { get; set; }          // זמן השאלה
        public string Status { get; set; } = "Open";   // סטטוס: Open / Answered
        public int? AnswerId { get; set; }             // מזהה תשובה (nullable)
    }

    






}