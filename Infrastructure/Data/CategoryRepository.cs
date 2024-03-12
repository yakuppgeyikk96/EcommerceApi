using EcommerceApi.Core.Models;
using EcommerceApi.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EcommerceApi.Infrastructure.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categoryCollection;
    
    public CategoryRepository(IOptions<CategoryDatabaseSettings> categoryStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(categoryStoreDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(categoryStoreDatabaseSettings.Value.DatabaseName);
        _categoryCollection =
            mongoDatabase.GetCollection<Category>(categoryStoreDatabaseSettings.Value.CategoriesCollectionName);
    }
    
    public Task<List<Category>> GetAsync()
    {
        return _categoryCollection.Find(_ => true).ToListAsync();
    }

    public Task<Category> GetAsync(string id)
    {
        return _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task CreateAsync(Category newCategory)
    {
        return _categoryCollection.InsertOneAsync(newCategory);
    }

    public Task UpdateAsync(string id, Category updatedCategory)
    {
        return _categoryCollection.ReplaceOneAsync(x => x.Id == id, updatedCategory);
    }

    public Task RemoveAsync(string id)
    {
        return _categoryCollection.DeleteOneAsync(x => x.Id == id);
    }
}