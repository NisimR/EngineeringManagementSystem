﻿namespace EngineeringManagementSystem.API.Models
{
    public class AnswerRequest
    {
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int AnsweredBy { get; set; }
    }
}
