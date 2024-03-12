using EcommerceApi.Core.Models;
using EcommerceApi.Core.Repositories;

namespace EcommerceApi.Core.Services;

public class ProductService(IProductRepository productRepository)
{
    public async Task<List<Product>> GetAsync() =>
        await productRepository.GetAsync();

    public async Task<Product?> GetAsync(string id) =>
        await productRepository.GetAsync(id);

    public async Task CreateAsync(Product newProduct) =>
        await productRepository.CreateAsync(newProduct);

    public async Task UpdateAsync(string id, Product updatedProduct) =>
        await productRepository.UpdateAsync(id, updatedProduct);

    public async Task RemoveAsync(string id) =>
        await productRepository.RemoveAsync(id);
}