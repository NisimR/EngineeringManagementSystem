namespace EngineeringManagementSystem.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // לדוגמה: "Engineer", "ProjectManager"
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
