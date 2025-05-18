using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Models
{
    [Index(nameof(Username), IsUnique = true)]

    public class User
    {

        //automatic generated
        public int Id { get; set; }

       
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // לדוגמה: "Engineer", "ProjectManager"
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
