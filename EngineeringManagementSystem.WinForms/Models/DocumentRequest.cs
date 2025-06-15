using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringManagementSystem.WinForms.Models
{
    public class DocumentRequest
    {
        public int PartNumberDoc { get; set; }
        public string PathDoc { get; set; }
        public string DocName { get; set; }
        public string AuthorName { get; set; }
        public string ReviewerName { get; set; }
        public string ApproverName { get; set; }
        public int EngProjId { get; set; }
    }
}
