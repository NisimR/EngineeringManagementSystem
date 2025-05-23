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
    public class QuestionsController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public QuestionsController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
public async Task<IActionResult> GetAll()
{
    var questions = await _context.Questions.ToListAsync();

    var userIds = questions.Select(q => q.AskedByUserId).Distinct().ToList();

    var users = await _context.Users
        .Where(u => userIds.Contains(u.UserId))
        .ToDictionaryAsync(u => u.UserId, u => u.FullName);

    var result = questions.Select(q => new QuestionDTO
    {
        QuestionId = q.QuestionId,
        QuestionText = q.QuestionText,
        AskedByUser = users.ContainsKey(q.AskedByUserId) ? users[q.AskedByUserId] : "לא ידוע",
        DocumentRevisionId = q.DocumentRevisionId,
        AskedAt = q.AskedAt,
        Answer = "", // אם אין קשר לתשובה, אפשר להשאיר ריק
        Status = q.Status
    });

    return Ok(result);
}


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.QuestionText))
            {
                return BadRequest("שאלה לא יכולה להיות ריקה.");
            }

            var question = new Question
            {
                AskedByUserId = request.AskedByUserId,
                DocumentRevisionId = request.DocumentRevisionId,
                QuestionText = request.QuestionText,
                AskedAt = DateTime.Now,
                Status = "Open"
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

    }

}
