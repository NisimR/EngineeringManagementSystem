using EngineeringManagementSystem.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace EngineeringManagementSystem.API.Models
{

    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; } // ← נדרש לשם אימות

        [Required]

        public string Role { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        

       
        
    }



}
