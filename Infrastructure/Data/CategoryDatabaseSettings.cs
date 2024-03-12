namespace EcommerceApi.Infrastructure.Data;

public class CategoryDatabaseSettings
{
    public string ConnectionString { get; init; } = null!;
    public string DatabaseName { get; init; } = null!;
    public string CategoriesCollectionName { get; init; } = null!;
}