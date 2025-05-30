using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class EngineeringProject
    {
        public int EngProjId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectManagerId { get; set; }
    }
}
