using EcommerceApi.Core.Models;

namespace EcommerceApi.Core.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAsync();
    Task<Category> GetAsync(string id);
    Task CreateAsync(Category newCategory);
    Task UpdateAsync(string id, Category updatedCategory);
    Task RemoveAsync(string id);
}