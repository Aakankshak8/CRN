using Crn_Api.Models;
using Crn_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crn_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _repository.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        var createdProduct = await _repository.AddAsync(product);

        return Ok(createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        var updatedProduct = await _repository.UpdateAsync(id, product);

        if (updatedProduct == null)
            return NotFound();

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return Ok("Product deleted successfully");
    }
}