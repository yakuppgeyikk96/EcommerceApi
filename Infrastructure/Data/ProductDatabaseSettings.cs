namespace EcommerceApi.Infrastructure.Data;

public class ProductDatabaseSettings
{
  public string ConnectionString { get; init; } = null!;
  public string DatabaseName { get; init; } = null!;
  public string ProductsCollectionName { get; init; } = null!;
}