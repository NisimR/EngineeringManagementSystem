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

    // 🔍 שליפת כל פריטי הייצור לפי פרויקט
    [HttpGet("by-project/{projectId}")]
    public async Task<ActionResult<IEnumerable<ProductionItemDTO>>> GetByProject(int projectId)
    {
        var items = await _context.ProductionItems
            .Where(i => i.ProductionProjectId == projectId)
            .Select(i => new ProductionItemDTO
            {
                Id = i.ProductionItemId,
                ItemName = i.PartName,
                Quantity = i.Quantity,
                ProjectNumber = i.ProductionProjectId,
                DocumentNumber = i.DocumentId
            }).ToListAsync();

        return Ok(items);
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
            Id = item.ProductionItemId,
            ItemName = item.PartName,
            Quantity = item.Quantity,
            ProjectNumber = item.ProductionProjectId,
            DocumentNumber = item.DocumentId
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
