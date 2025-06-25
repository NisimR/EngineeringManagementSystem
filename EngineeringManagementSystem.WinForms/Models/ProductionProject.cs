using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringManagementSystem.WinForms.Models
{
    internal class ProductionProject
    {

       
        public int ProdProjId { get; set; }
        public string ProjectName { get; set; }

        public int ProjectManagerId { get; set; }

        
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<int> ProductionItem { get; set; }

    }
}
