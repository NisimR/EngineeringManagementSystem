namespace EngineeringManagementSystem.API.Models
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int AnsweredBy { get; set; }
        public DateTime AnsweredAt { get; set; }
    }
}
