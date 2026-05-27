using Crn_Api.Models;
using Crn_Api.Repositories;

namespace Crn_Api.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _repository.AddAsync(product);
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            return await _repository.UpdateAsync(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}