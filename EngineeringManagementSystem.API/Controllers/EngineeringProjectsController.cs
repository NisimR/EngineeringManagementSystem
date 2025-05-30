using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineeringProjectsController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public EngineeringProjectsController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        // שליפת כל הפרויקטים
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineeringProject>>> GetAll()
        {
            return await _context.EngineeringProjects.ToListAsync();
        }

        //  שליפת פרויקט לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineeringProject>> GetById(int id)
        {
            var project = await _context.EngineeringProjects.FindAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        //  יצירת פרויקט חדש
        [HttpPost]
        public async Task<ActionResult<EngineeringProject>> Create(EngineeringProject project)
        {
            project.CreatedAt = DateTime.Now;

            _context.EngineeringProjects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = project.EngProjId }, project);
        }

        //  עדכון פרויקט קיים
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EngineeringProject project)
        {
            if (id != project.EngProjId)
                return BadRequest("מספר מזהה לא תואם.");

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        //   מחיקת פרויקט לפי מזהה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.EngineeringProjects.FindAsync(id);
            if (project == null)
                return NotFound();

            _context.EngineeringProjects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // בדיקה אם פרויקט קיים
        private bool ProjectExists(int id)
        {
            return _context.EngineeringProjects.Any(e => e.EngProjId == id);
        }
    }
}
