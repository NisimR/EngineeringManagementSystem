// ✅ מחלקה: UserDTO
// מייצגת את המשתמש כפי שהוא יישלח  אל השרת לאחר התחברות
namespace EngineeringManagementSystem.WinForms.Models
{
   
    public class UserDAO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // "Operator", "Engineer", "ProjectManager", "Admin"

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}