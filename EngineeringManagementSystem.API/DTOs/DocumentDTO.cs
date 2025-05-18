namespace EngineeringManagementSystem.API.DTOs
{
    public class DocumentDTO
    {
        //public int DocumentId { get; set; }
        public int PartNumberDoc { get; set; }
        public string PathDoc { get; set; }
        public string FileName { get; set; }
        public char Rev { get; set; }
        public string Author { get; set; }
        public string Reviewer { get; set; }
        public string Approver { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
