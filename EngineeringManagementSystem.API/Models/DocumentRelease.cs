namespace EngineeringManagementSystem.API.Models
{
    public class DocumentRelease
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int AuthorId { get; set; }
        public int? ReviewerId { get; set; }
        public int? ApproverId { get; set; }
        public bool AuthorSigned { get; set; }
        public bool ReviewerSigned { get; set; }
        public bool ApproverSigned { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
