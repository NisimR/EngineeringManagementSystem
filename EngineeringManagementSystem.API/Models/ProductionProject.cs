using System.ComponentModel.DataAnnotations;

namespace EngineeringManagementSystem.API.Models
{
    public class ProductionProject
    {
        [Key]
        public int ProdProjId { get; set; }
        public string ProjectName { get; set; }

        public int ProjectManagerId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<int> Documents { get; set; }







    }
}
