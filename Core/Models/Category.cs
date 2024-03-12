using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceApi.Core.Models;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BindNever]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;

    public List<Product> Products { get; set; } = [];
}