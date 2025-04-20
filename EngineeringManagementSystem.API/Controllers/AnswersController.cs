using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public AnswersController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        // הוספת תשובה לשאלה
        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AnswerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.AnswerText))
                return BadRequest("יש להזין טקסט תשובה");

            // בדיקה אם השאלה קיימת
            var question = await _context.Questions.FindAsync(request.QuestionId);
            if (question == null)
                return NotFound("שאלה לא נמצאה");

            // הוספת תשובה
            var answer = new Answer
            {
                QuestionId = request.QuestionId,
                AnswerText = request.AnswerText,
                AnsweredBy = request.AnsweredBy,
                AnsweredAt = DateTime.Now
            };

            _context.Answers.Add(answer);

            // עדכון סטטוס השאלה ל-Answered
            question.Status = "Answered";

            await _context.SaveChangesAsync();

            return Ok(new { message = "התשובה נוספה בהצלחה", answer.Id });
        }

        // שליפת תשובות לשאלה מסוימת
        [HttpGet("{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetAnswers(int questionId)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .Select(a => new AnswerDTO
                {
                    Id = a.Id,
                    QuestionId = a.QuestionId,
                    AnswerText = a.AnswerText,
                    AnsweredBy = a.AnsweredBy,
                    AnsweredAt = a.AnsweredAt
                }).ToListAsync();

            return Ok(answers);
        }
    }
}
