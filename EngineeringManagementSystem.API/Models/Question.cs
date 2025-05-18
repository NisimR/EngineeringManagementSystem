using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringManagementSystem.API.Models
{
    
    public class Question
    {
        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        public int AskedByUserId { get; set; }

        public int DocumentRevisionId { get; set; }

        public required string QuestionText { get; set; }

        public DateTime AskedAt { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Open";
        
    }

}
