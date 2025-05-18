namespace EngineeringManagementSystem.API.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int AnsweredByUserId { get; set; }

        public string AnswerText { get; set; }
        public DateTime AnsweredAt { get; set; } = DateTime.Now;

    }


}
