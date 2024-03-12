using EcommerceApi.Core.Models;
using EcommerceApi.Core.Repositories;

namespace EcommerceApi.Core.Services;

public class CategoryService(ICategoryRepository categoryRepository)
{
    public Task<List<Category>> GetAsync()
    {
        var categories = categoryRepository.GetAsync();

        return categories;
    }
    
    public async Task<Category?> GetAsync(string id) =>
        await categoryRepository.GetAsync(id);
    
    public Task CreateAsync(Category newCategory) =>
        categoryRepository.CreateAsync(newCategory);

    public Task UpdateAsync(string id, Category updatedCategory) =>
        categoryRepository.UpdateAsync(id, updatedCategory);

    public Task RemoveAsync(string id) =>
        categoryRepository.RemoveAsync(id);
}