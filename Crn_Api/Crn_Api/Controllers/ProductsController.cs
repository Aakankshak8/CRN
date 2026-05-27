using Crn_Api.Models;
using Crn_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crn_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var newProduct = await _repository.AddAsync(product);

            return Ok(newProduct);
        }

        // PUT: api/products
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var updatedProduct = await _repository.UpdateAsync(product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok("Product Deleted Successfully");
        }
    }
}