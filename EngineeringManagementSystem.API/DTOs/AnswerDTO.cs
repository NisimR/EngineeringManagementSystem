namespace EngineeringManagementSystem.API.DTOs
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public string  QuestionText { get; set; }
        public string  AnsweredByUser { get; set; }

        public DateTime AnsweredAt { get; set; } 
    }
}
