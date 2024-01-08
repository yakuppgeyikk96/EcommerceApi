using EcommerceApi.Core.Models;

namespace EcommerceApi.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAsync();
    Task<Product> GetAsync(string id);
    Task CreateAsync(Product newBook);
    Task UpdateAsync(string id, Product updatedBook);
    Task RemoveAsync(string id);
}