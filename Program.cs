using EcommerceApi.Core.Repositories;
using EcommerceApi.Infrastructure.Data;
using EcommerceApi.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductDatabaseSettings>(
    builder.Configuration.GetSection("EcommerceDatabase")
);

builder.Services.Configure<CategoryDatabaseSettings>(builder.Configuration.GetSection("EcommerceDatabase"));

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ProductService>();

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<CategoryService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();