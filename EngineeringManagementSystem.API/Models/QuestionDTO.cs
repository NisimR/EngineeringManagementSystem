namespace EngineeringManagementSystem.API.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Status { get; set; }
        public DateTime AskedAt { get; set; }
        public int AskedBy { get; set; }

        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public int? DocumentId { get; set; }
        public string? DocumentName { get; set; }

    }
}
