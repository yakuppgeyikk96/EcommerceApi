
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceApi.Core.Models;

public class Product
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [BindNever]
  public string? Id { get; set; }

  public string Title { get; set; } = null!;

  public string Description { get; set; } = null!;

  public decimal Price { get; set; }

  public int Stock { get; set; }

  public double Rate { get; set; }
}