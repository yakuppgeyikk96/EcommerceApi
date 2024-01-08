using EcommerceApi.Core.Models;
using EcommerceApi.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EcommerceApi.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productsCollection;

    public ProductRepository(
        IOptions<ProductDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _productsCollection = mongoDatabase.GetCollection<Product>(
            bookStoreDatabaseSettings.Value.ProductsCollectionName);
    }
    public Task<List<Product>> GetAsync()
    {
        return _productsCollection.Find(_ => true).ToListAsync();
    }

    public Task<Product> GetAsync(string id)
    {
        return _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task CreateAsync(Product newBook)
    {
        return _productsCollection.InsertOneAsync(newBook);
    }

    public Task UpdateAsync(string id, Product updatedBook)
    {
        return _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
    }

    public Task RemoveAsync(string id)
    {
        return _productsCollection.DeleteOneAsync(x => x.Id == id);
    }
}