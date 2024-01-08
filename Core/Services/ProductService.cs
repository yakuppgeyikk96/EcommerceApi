using EcommerceApi.Core.Models;
using EcommerceApi.Core.Repositories;

namespace EcommerceApi.Core.Services;

public class ProductService(IProductRepository productRepository)
{
    public async Task<List<Product>> GetAsync() =>
        await productRepository.GetAsync();

    public async Task<Product?> GetAsync(string id) =>
        await productRepository.GetAsync(id);

    public async Task CreateAsync(Product newBook) =>
        await productRepository.CreateAsync(newBook);

    public async Task UpdateAsync(string id, Product updatedBook) =>
        await productRepository.UpdateAsync(id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await productRepository.RemoveAsync(id);
}