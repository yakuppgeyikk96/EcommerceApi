using EcommerceApi.Core.Models;
using EcommerceApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(CategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public Task<List<Category>> Get()
    {
        return categoryService.GetAsync();
    }

    [HttpGet("{id:length(24)}", Name = "Get")]
    public async Task<ActionResult<Category>> Get(string id)
    {
        var category = await categoryService.GetAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return category;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Category newCategory)
    {
        await categoryService.CreateAsync(newCategory);

        return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Category updatedCategory)
    {
        var category = await categoryService.GetAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        updatedCategory.Id = category.Id;

        await categoryService.UpdateAsync(id, updatedCategory);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var category = await categoryService.GetAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        await categoryService.RemoveAsync(id);

        return NoContent();
    }
}