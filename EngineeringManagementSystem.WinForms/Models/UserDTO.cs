// ✅ מחלקה: UserDTO
// מייצגת את המשתמש כפי שהוא מתקבל מהשרת לאחר התחברות
namespace EngineeringManagementSystem.WinForms.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}