// ✅ מחלקה: Session (סטטי)
// מחזיקה את המשתמש המחובר כרגע – נגישה מכל מקום במערכת
namespace EngineeringManagementSystem.WinForms.Models
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        public static string DisplayText => $"Connected as: {FullName} ({Role})";

    }
}