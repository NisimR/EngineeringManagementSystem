using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class ProductionItemDTO
    {
        public int ProductionItemId { get; set; }
        public int DocumentId { get; set; }
        public string PartName { get; set; }

        public int ProductionProjectId { get; set; }
        public string ProductionProjectName { get; set; } // 🟢 חדש

        public int Quantity { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; } // 🟢 חדש

        public DateTime CreatedAt { get; set; }
    }
}
