using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringManagementSystem.API.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        public int PartNumberDoc { get; set; } // מזהה או מספר חלק

        public string PathDoc { get; set; }

        public string DocName { get; set; }

        public char Rev { get; set; }

        public int? AuthorId { get; set; }
        public int? ReviewerId { get; set; }
        public int? ApproverId { get; set; }

        public bool AuthorSigned { get; set; } = false;
        public bool ReviewerSigned { get; set; } = false;
        public bool ApproverSigned { get; set; } = false;

        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }

        // ✅ קישור לפרויקט הנדסה
        public int EngProjId { get; set; }

        
    }

}
