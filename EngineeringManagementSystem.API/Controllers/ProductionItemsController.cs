using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.DTOs;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class ProductionItemsController : ControllerBase
{
    private readonly EngineeringManegementDbContext _context;

    public ProductionItemsController(EngineeringManegementDbContext context)
    {
        _context = context;
    }

    // ➕ הוספת פריט חדש לייצור
    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] ProductionItemRequest request)
    {
        // שליפת שם חלק מתוך המסמך
        var document = await _context.Documents.FirstOrDefaultAsync(d => d.DocumentId == request.DocumentId);
        if (document == null)
            return BadRequest("המסמך לא נמצא");

        var item = new ProductionItem
        {
            ProductionProjectId = request.ProductionProjectId,
            DocumentId = request.DocumentId,
            Quantity = request.Quantity,
            PartName = document.DocName, // או כל שדה אחר שייצג את שם החלק
            CreatedById = request.CreatedById,
            CreatedAt = DateTime.Now
        };

        _context.ProductionItems.Add(item);
        await _context.SaveChangesAsync();

        return Ok(new { item });
    }

    [HttpGet("byProject/{prodProjId}")]
    public async Task<ActionResult<IEnumerable<ProductionItemDTO>>> GetByProject(int prodProjId)
    {
        var items = await _context.ProductionItems
            .Where(p => p.ProductionProjectId == prodProjId)
            .ToListAsync();

        var result = items.Select(p => new ProductionItemDTO
        {
            ProductionItemId = p.ProductionItemId,
            DocumentId = p.DocumentId,
            DocumentName = _context.Documents.FirstOrDefault(d => d.DocumentId == p.DocumentId)?.DocName,
            PartName = p.PartName,
            ProductionProjectId = p.ProductionProjectId,
            ProductionProjectName = _context.ProductionProjects.FirstOrDefault(pp => pp.ProdProjId == p.ProductionProjectId)?.ProjectName,
            Quantity = p.Quantity,
            CreatedById = p.CreatedById,
            CreatedByName = _context.Users.FirstOrDefault(u => u.UserId == p.CreatedById)?.FullName,
            CreatedAt = p.CreatedAt
        });

        return Ok(result);
    }
    // 🔍 שליפת פריט ייצור לפי ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductionItemDTO>> GetById(int id)
    {
        var item = await _context.ProductionItems.FindAsync(id);

        if (item == null)
            return NotFound();

        return Ok(new ProductionItemDTO
        {
            ProductionItemId = item.ProductionItemId,
            DocumentId = item.DocumentId,
            DocumentName = _context.Documents.FirstOrDefault(d => d.DocumentId == item.DocumentId)?.DocName,
            PartName = item.PartName,
            ProductionProjectId = item.ProductionProjectId,
            ProductionProjectName = _context.ProductionProjects.FirstOrDefault(pp => pp.ProdProjId == item.ProductionProjectId)?.ProjectName,
            Quantity = item.Quantity,
            CreatedById = item.CreatedById,
            CreatedByName = _context.Users.FirstOrDefault(u => u.UserId == item.CreatedById)?.FullName,
            CreatedAt = item.CreatedAt
        });
    }



    // 📝 אופציונלי: עדכון פריט ייצור
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] ProductionItemRequest request)
    {
        var existingItem = await _context.ProductionItems.FindAsync(id);
        if (existingItem == null)
            return NotFound();

        var document = await _context.Documents.FindAsync(request.DocumentId);
        if (document == null)
            return BadRequest("המסמך לא קיים");

        existingItem.DocumentId = request.DocumentId;
        existingItem.Quantity = request.Quantity;
        existingItem.PartName = document.DocName;

        await _context.SaveChangesAsync();
        return Ok("פריט עודכן בהצלחה");
    }
}
