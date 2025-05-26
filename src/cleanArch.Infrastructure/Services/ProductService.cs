using cleanArch.Application.Interfaces;
using cleanArch.Domain.Entities;

namespace cleanArch.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products;

    public ProductService(IProductService @object)
    {
        _products = new List<Product>
        {
            new Product { Id = Guid.NewGuid().ToString(), Name = "Product 1", Price = 10.99m },
            new Product { Id = Guid.NewGuid().ToString(), Name = "Product 2", Price = 20.99m },
            new Product { Id = Guid.NewGuid().ToString(), Name = "Product 3", Price = 30.99m }
        };
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
    public Product? GetById(string id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        // gen uuid for productId
        _products.Add(product);
    }
}