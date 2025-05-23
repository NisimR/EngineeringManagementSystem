using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.DTOs;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
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

        /*[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var answers = await _context.Answers.ToListAsync();
            return Ok(answers);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var answers = await _context.Answers.ToListAsync();

            var userIds = answers.Select(a => a.AnsweredByUserId).Distinct().ToList();

            var users = await _context.Users
                .Where(u => userIds.Contains(u.UserId))
                .ToDictionaryAsync(u => u.UserId, u => u.FullName);

            var result = answers.Select(a => new AnswerDTO
            {
                AnswerId = a.AnswerId,
                AnswerText = a.AnswerText,
                AnsweredByUser = users.ContainsKey(a.AnsweredByUserId) ? users[a.AnsweredByUserId] : "לא ידוע",
                //QuestionText = a.QuestionText,
                AnsweredAt = a.AnsweredAt
            });

            return Ok(result);
        }

        [HttpGet("by-question/{questionId}")]
        public async Task<IActionResult> GetByQuestion(int questionId)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();

            return Ok(answers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Answer answer)
        {
            answer.AnsweredAt = DateTime.Now;
            _context.Answers.Add(answer);

            var question = await _context.Questions.FindAsync(answer.QuestionId);
            if (question != null)
            {
                question.Status = "Answered";
            }

            await _context.SaveChangesAsync();
            return Ok(answer);
        }
    }
}
