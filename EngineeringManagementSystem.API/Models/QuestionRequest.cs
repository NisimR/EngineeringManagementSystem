namespace EngineeringManagementSystem.API.Models
{
    public class QuestionRequest
    {
        public int AskedBy { get; set; }
        public int? ProjectId { get; set; }
        public int? DocumentId { get; set; }
        public string QuestionText { get; set; }
    }
}
