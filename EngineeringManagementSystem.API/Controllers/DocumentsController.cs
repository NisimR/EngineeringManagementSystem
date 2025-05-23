using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public DocumentsController(EngineeringManegementDbContext context)
        {
            _context = context;
        }

        // helper function – מחפש לפי שם
        private int? GetUserIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var user = _context.Users.FirstOrDefault(u => u.FullName == name);
            return user?.UserId;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(int id)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null)
                return NotFound();

            return doc;
        }

        // POST: api/Documents
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentRequest request)
        {
            var doc = new Document
            {
                PartNumberDoc = request.PartNumberDoc,
                PathDoc = request.PathDoc,
                DocName = request.DocName,
                Rev = 'A', 
                AuthorId = GetUserIdByName(request.AuthorName),
                ReviewerId = GetUserIdByName(request.ReviewerName),
                ApproverId = GetUserIdByName(request.ApproverName),
                AuthorSigned = false,
                ReviewerSigned = false,
                ApproverSigned = false,
                IsReleased = false,
                ReleaseDate = null
            };

            _context.Documents.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = doc.DocumentId }, doc);
        }

       
    }
}
