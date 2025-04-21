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

        // הוספת תשובה חדשה לשאלה
        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AnswerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.AnswerText))
                return BadRequest("יש להזין טקסט תשובה");

            var question = await _context.Questions.FindAsync(request.QuestionId);
            if (question == null)
                return NotFound("שאלה לא נמצאה");

            var answer = new Answer
            {
                QuestionId = request.QuestionId,
                AnswerText = request.AnswerText,
                AnsweredBy = request.AnsweredBy,
                AnsweredAt = DateTime.Now
            };

            _context.Answers.Add(answer);
            question.Status = "Answered";
            await _context.SaveChangesAsync();

            return Ok(new { message = "התשובה נוספה בהצלחה", answer.Id });
        }

        // שליפת כל התשובות לשאלה
        [HttpGet("{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetAnswersByQuestion(int questionId)
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
