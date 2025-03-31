namespace EngineeringManagementSystem.API.Models
{
    public class Revision
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string RevisionNumber { get; set; }
        public string FilePath { get; set; }
        public DateTime RevisionDate { get; set; }
        public string Notes { get; set; }
    }
}
