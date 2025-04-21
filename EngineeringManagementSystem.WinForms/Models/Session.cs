// ✅ מחלקה: Session (סטטי)
// מחזיקה את המשתמש המחובר כרגע – נגישה מכל מקום במערכת
namespace EngineeringManagementSystem.WinForms.Models
{
    public static class Session
    {
        public static UserDTO CurrentUser { get; set; }
    }
}