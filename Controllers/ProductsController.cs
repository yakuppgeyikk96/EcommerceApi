
using EcommerceApi.Core.Models;
using EcommerceApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductService productsService) : ControllerBase
{
  [HttpGet]
  public async Task<List<Product>> Get()
  {
    return await productsService.GetAsync();
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Product>> Get(string id)
  {
    var product = await productsService.GetAsync(id);

    if (product is null)
    {
      return NotFound();
    }

    return product;
  }

  [HttpPost]
  public async Task<IActionResult> Post(Product newProduct)
  {
    await productsService.CreateAsync(newProduct);

    return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, Product updatedProduct)
  {
    var product = await productsService.GetAsync(id);

    if (product is null)
    {
      return NotFound();
    }

    updatedProduct.Id = product.Id;

    await productsService.UpdateAsync(id, updatedProduct);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var product = await productsService.GetAsync(id);

    if (product is null)
    {
      return NotFound();
    }

    await productsService.RemoveAsync(id);

    return NoContent();
  }
}