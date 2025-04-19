using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoriesController(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryRequest request)
    {
        var category = new Category(request.Name, request.Description);
        await _categoryRepository.AddAsync(category);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateCategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        category.UpdateDetails(request.Name, request.Description);
        await _categoryRepository.UpdateAsync(category);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        await _categoryRepository.DeleteAsync(category);
        return NoContent();
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        category.Activate();
        await _categoryRepository.UpdateAsync(category);

        return NoContent();
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        category.Deactivate();
        await _categoryRepository.UpdateAsync(category);

        return NoContent();
    }
}

public record CreateCategoryRequest(string Name, string Description); 