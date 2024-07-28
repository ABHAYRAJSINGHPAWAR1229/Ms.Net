using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var products = new Product[] {
    new(1, "Garnier faceWash","193",DateOnly.FromDateTime(DateTime.Now.AddDays(-32)),DateOnly.FromDateTime(DateTime.Now.AddDays(32)),true),
    new(2, "Glow And Lovely","95", DateOnly.FromDateTime(DateTime.Now.AddDays(-48)),DateOnly.FromDateTime(DateTime.Now.AddDays(42)),true),
    new(3, "Himami Cream","120", DateOnly.FromDateTime(DateTime.Now.AddDays(-12)),DateOnly.FromDateTime(DateTime.Now.AddDays(82)), true),
    new(4, "Ponds White Beauty", "172",DateOnly.FromDateTime(DateTime.Now.AddDays(-66)),DateOnly.FromDateTime(DateTime.Now.AddDays(22)),true),
    new(5, "Nevia","75", DateOnly.FromDateTime(DateTime.Now.AddDays(-22)),DateOnly.FromDateTime(DateTime.Now.AddDays(82)), true)
};

var productAll = app.MapGroup("/product");
productAll.MapGet("/", () => products);

var SingleProduct = app.MapGroup("/product");
SingleProduct.MapGet("/{id}", (int id) =>
    products.FirstOrDefault(a => a.Id == id) is { } Product
        ? Results.Ok(Product)
        : Results.NotFound());



app.Run();

public record Product(int Id, string? Product_Name,string? price, DateOnly? ManufactureDate = null,DateOnly? ExpiryDate=null, bool? Available = false);

[JsonSerializable(typeof(Product[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
