using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public QuestionsController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        // שליפת כל השאלות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions()
        {
            var questions = await _context.Questions
                .Include(q => q.Project)
                .Include(q => q.Document)
                .Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    Status = q.Status,
                    AskedAt = q.AskedAt,
                    AskedBy = q.AskedBy,
                    ProjectId = q.ProjectId,
                    ProjectName = q.Project != null ? q.Project.ProjectName : null,
                    DocumentId = q.DocumentId,
                    DocumentName = q.Document != null ? q.Document.FileName : null
                }).ToListAsync();

            return Ok(questions);
        }

        // יצירת שאלה חדשה
        [HttpPost]
        public async Task<IActionResult> AskQuestion([FromBody] QuestionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.QuestionText))
                return BadRequest("יש להזין טקסט שאלה");

            var question = new Question
            {
                AskedBy = request.AskedBy,
                ProjectId = request.ProjectId,
                DocumentId = request.DocumentId,
                QuestionText = request.QuestionText,
                Status = "Open",
                AskedAt = DateTime.Now
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(new { message = "השאלה נשלחה בהצלחה", question.Id });
        }
    }
}
