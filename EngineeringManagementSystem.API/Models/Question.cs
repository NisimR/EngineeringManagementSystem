namespace EngineeringManagementSystem.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int AskedBy { get; set; }
        public int? ProjectId { get; set; }
        public int? DocumentId { get; set; }
        public string QuestionText { get; set; }
        public DateTime AskedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Open"; // Open / Answered

    }
}
