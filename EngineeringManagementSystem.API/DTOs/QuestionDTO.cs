using EngineeringManagementSystem.API.Models;

namespace EngineeringManagementSystem.API.DTOs
{
 
        public class QuestionDTO
        {
        
        public string QuestionText { get; set; }
        public int DocumentId { get; set; }
        public int AskedByUserId { get; set; }
        public DateTime AskedAt { get; set; }
        public string Status { get; set; } = "Open";
        public int? AnswerId { get; set; }


    }

    }





