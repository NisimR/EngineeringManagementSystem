using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class DocumentDTO
    {
        public int DocumentId { get; set; }
        public string DocName { get; set; }
        public string Rev { get; set; }
        public bool IsReleased { get; set; }
    }
}
