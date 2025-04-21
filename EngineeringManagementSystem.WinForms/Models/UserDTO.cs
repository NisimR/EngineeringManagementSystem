// ✅ מחלקה: UserDTO
// מייצגת את המשתמש כפי שהוא מתקבל מהשרת לאחר התחברות
namespace EngineeringManagementSystem.WinForms.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // "Operator", "Engineer", "ProjectManager", "Admin"
    }
}