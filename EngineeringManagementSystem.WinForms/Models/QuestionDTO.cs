// ✅ מחלקה: QuestionDTO
// מייצגת שאלה כפי שמתקבלת מהשרת (כולל מידע מלא)
using System;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Status { get; set; }
        public DateTime AskedAt { get; set; }
        public int AskedBy { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public int? DocumentId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public int? AssignedTo { get; set; }
        public string AssignedToName { get; set; } = string.Empty;
    }
}