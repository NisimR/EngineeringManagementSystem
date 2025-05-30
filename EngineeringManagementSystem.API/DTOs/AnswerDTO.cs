namespace EngineeringManagementSystem.API.DTOs
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }

        public string AnswerText { get; set; }

        public int AnsweredByUserId { get; set; }

        public DateTime AnsweredAt { get; set; }
    }

}
