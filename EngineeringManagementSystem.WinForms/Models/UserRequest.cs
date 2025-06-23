using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EngineeringManagementSystem.WinForms.Models
{
    internal class UserRequest
    {

   
        
        public string Username { get; set; }

        
        public string FullName { get; set; }

        
        public string Password { get; set; } // ← נדרש לשם אימות

        

        public string Role { get; set; }


        
        public string Email { get; set; }

        
        public string PhoneNumber { get; set; }


    }
}
