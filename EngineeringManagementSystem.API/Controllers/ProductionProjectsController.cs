using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using EngineeringManagementSystem.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[ApiController]
[Route("api/[controller]")]
public class ProductionProjectsController : ControllerBase
{
    private readonly EngineeringManegementDbContext _context;

    public ProductionProjectsController(EngineeringManegementDbContext context)
    {
        _context = context;
    }

    // הוספת פרויקט
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] ProductionProject project)
    {
        _context.ProductionProjects.Add(project);
        await _context.SaveChangesAsync();
        return Ok(project);
    }

    [HttpPost("{projectId}/items")]
    public async Task<IActionResult> AddItemToProject(int projectId, [FromBody] ProductionItemRequest request)
    {
        var project = await _context.ProductionProjects.FindAsync(projectId);
        if (project == null)
            return NotFound();

        var item = new ProductionItem
        {
            ProductionProjectId = projectId,
            DocumentId = request.DocumentId,
            PartName = request.PartName,
            Quantity = request.Quantity,
            CreatedById = request.CreatedById,
            CreatedAt = DateTime.Now
        };

        _context.ProductionItems.Add(item);
        await _context.SaveChangesAsync();

        project.ProductionItemId.Add(item.ProductionItemId);
        _context.ProductionProjects.Update(project);
        await _context.SaveChangesAsync();

        return Ok(item);
    }

    // שליפת כל הפרויקטים
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _context.ProductionProjects.ToListAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductionProject(int id)
    {
        var project = await _context.ProductionProjects
            .FirstOrDefaultAsync(p => p.ProdProjId == id);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    // עדכון פרויקט
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] ProductionProject updated)
    {
        var project = await _context.ProductionProjects.FindAsync(id);
        if (project == null) return NotFound();

        project.ProjectName = updated.ProjectName;
        project.Description = updated.Description;
        project.ProjectManagerId = updated.ProjectManagerId;

        await _context.SaveChangesAsync();
        return Ok(project);
    }


}
