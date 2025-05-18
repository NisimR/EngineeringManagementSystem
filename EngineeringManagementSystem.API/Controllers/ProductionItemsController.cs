using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using EngineeringManagementSystem.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagementSystem.API.Controllers
{
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
            var item = new ProductionItem
            {
                ProductionProjectId = request.ProductionProjectId,
                DocumentId = request.DocumentId,
                Quantity = request.Quantity,
                CreatedAt = DateTime.Now
            };

            _context.ProductionItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(new {item});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productionItems = await _context.ProductionItems.ToListAsync();
            return Ok(productionItems);
        }


        // 🔍 שליפת כל פריטי הייצור לפי פרויקט
        [HttpGet("by-project/{projectId}")]
        public async Task<ActionResult<IEnumerable<ProductionItemDTO>>> GetByProject(int projectId)
        {
            var items = await _context.ProductionItems
                .Where(i => i.ProductionProjectId == projectId)
                .Select(i => new ProductionItemDTO
                {
                    Id = i.ProductionProjectId,
                    ItemName = i.PartName,
                    Quantity = i.Quantity,
                    ProjectNumber = i.ProductionProjectId,
                    DocumentNumber = i.DocumentId
                }).ToListAsync();

            return Ok(items);
        }

        // 🔍 שליפת פריט ייצור לפי מזהה מסמך
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionItemDTO>> GetById (int DocumentId)
        {
            var items = await _context.ProductionItems
                .Where(i => i.ProductionProjectId == DocumentId)
                .Select(i => new ProductionItemDTO
                {
                    Id = i.ProductionProjectId,
                    ItemName = i.PartName,
                    Quantity = i.Quantity,
                    ProjectNumber = i.ProductionProjectId,
                    DocumentNumber = i.DocumentId
                }).ToListAsync();

            return Ok(items);
        }
    }
}
