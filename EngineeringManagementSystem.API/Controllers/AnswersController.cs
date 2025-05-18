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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var answers = await _context.Answers.ToListAsync();
            return Ok(answers);
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
