using EcommerceApi.Core.Models;

namespace EcommerceApi.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAsync();
    Task<Product> GetAsync(string id);
    Task CreateAsync(Product newProduct);
    Task UpdateAsync(string id, Product updatedProduct);
    Task RemoveAsync(string id);
}