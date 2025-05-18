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
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            question.AskedAt = DateTime.Now;
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }
    }

}
