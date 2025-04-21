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
                .Include(q => q.AssignedToUser)
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
                    DocumentName = q.Document != null ? q.Document.FileName : null,
                    AssignedTo = q.AssignedTo,
                    AssignedToName = q.AssignedToUser != null ? q.AssignedToUser.FullName : null
                }).ToListAsync();

            return Ok(questions);
        }

        // יצירת שאלה חדשה
        [HttpPost]
        public async Task<IActionResult> AskQuestion([FromBody] QuestionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.QuestionText))
                return BadRequest("יש להזין טקסט שאלה");

            int? assignedTo = null;

            if (request.ProjectId.HasValue)
            {
                var manager = await _context.Users
                    .OfType<ProjectManager>()
                    .FirstOrDefaultAsync(u => u.ProjectId == request.ProjectId);

                if (manager != null)
                {
                    assignedTo = manager.Id;
                }
            }

            var question = new Question
            {
                AskedBy = request.AskedBy,
                ProjectId = request.ProjectId,
                DocumentId = request.DocumentId,
                QuestionText = request.QuestionText,
                Status = "Open",
                AskedAt = DateTime.Now,
                AssignedTo = assignedTo
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(new { message = "השאלה נשלחה בהצלחה", question.Id });
        }

        // ניתוב מחדש של שאלה
        [HttpPost("{id}/forward")]
        public async Task<IActionResult> ForwardQuestion(int id, [FromBody] int newUserId)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                return NotFound("שאלה לא נמצאה");

            question.AssignedTo = newUserId;
            await _context.SaveChangesAsync();

            return Ok(new { message = "השאלה נותבה מחדש", question.Id });
        }
    }
}
