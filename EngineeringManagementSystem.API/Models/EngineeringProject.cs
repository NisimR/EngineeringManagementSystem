using System.ComponentModel.DataAnnotations;

namespace EngineeringManagementSystem.API.Models
{
    public class EngineeringProject
    {
        [Key]
        public int EngProjId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ProjectManagerId { get; set; }

        public List<Document> Documents { get; set; }
        

        
    }
}
