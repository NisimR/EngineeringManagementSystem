using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Requests;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("byProject/{projectId}")]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetByProject(int projectId)
        {
            var docIds = await _context.Documents
                .Where(d => d.EngProjId == projectId)
                .Select(d => d.DocumentId)
                .ToListAsync();

            var questions = await _context.Questions
                .Where(q => docIds.Contains(q.DocumentId))
                .ToListAsync();

            var result = questions.Select(q =>
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == q.AskedByUserId);
                var answer = _context.Answers.FirstOrDefault(a => a.AnswerId == q.AnswerId);
                var answerUser = answer != null ? _context.Users.FirstOrDefault(u => u.UserId == answer.AnsweredByUserId) : null;

                return new QuestionDTO
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    DocumentId = q.DocumentId,
                    AskedByUserId = q.AskedByUserId,
                    AskedByUserName = user?.FullName,
                    AskedAt = q.AskedAt,
                    Status = q.Status,
                    AnswerId = q.AnswerId,
                    AnsweredByUserName = answerUser?.FullName
                };
            });

            return Ok(result);
        }




        [HttpGet("byDocument/{documentId}")]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetByDocument(int documentId)
        {
            var questions = await _context.Questions
                .Where(q => q.DocumentId == documentId)
                .ToListAsync();

            var result = questions.Select(q => new QuestionDTO
            {
                QuestionId = q.QuestionId,
                QuestionText = q.QuestionText,
                DocumentId = q.DocumentId,
                AskedByUserId = q.AskedByUserId,
                AskedAt = q.AskedAt,
                Status = q.Status,
                AnswerId = q.AnswerId 
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionRequest dto)
        {
            var question = new Question
            {
                QuestionText = dto.QuestionText,
                DocumentId = dto.DocumentId,
                AskedByUserId = dto.AskedByUserId,
                AskedAt = DateTime.Now,
                Status = "Open"
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}