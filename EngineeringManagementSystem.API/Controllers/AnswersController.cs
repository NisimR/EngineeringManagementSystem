using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using EngineeringManagementSystem.API.DTOs;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<Answer>>> GetAll()
    {
        return await _context.Answers.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AnswerDTO dto)
    {
        var question = await _context.Questions.FindAsync(dto.QuestionId);
        if (question == null)
            return NotFound("שאלה לא קיימת.");

        var answer = new Answer
        {
            QuestionId = dto.QuestionId,
            AnswerText = dto.AnswerText,
            AnsweredByUserId = dto.AnsweredByUserId,
            AnsweredAt = DateTime.Now
        };

        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();

        question.AnswerId = answer.AnswerId;
        question.Status = "Answered";
        await _context.SaveChangesAsync();

        return Ok();
    }
}