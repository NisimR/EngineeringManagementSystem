using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringManagementSystem.API.Models
{
    public class ProductionItem
    {
        public int ProductionItemId { get; set; } // מזהה ייחודי לפריט ייצור
        public int DocumentId { get; set; }
        public string PartName { get; set; }        
        public int ProductionProjectId { get; set; }
        public int Quantity { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
       
    }

}
