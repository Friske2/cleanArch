using cleanArch.Application.Exceptions;
using cleanArch.Application.Interfaces;
using cleanArch.Domain.Entities;

namespace cleanArch.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = Guid.NewGuid().ToString(), Name = "Product 1", Price = 10.99m },
        new Product { Id = Guid.NewGuid().ToString(), Name = "Product 2", Price = 20.99m },
        new Product { Id = Guid.NewGuid().ToString(), Name = "Product 3", Price = 30.99m }
    };

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

    public void Update(Product product)
    {
        // check product id is not null or empty 
        if (string.IsNullOrEmpty(product.Id))
        {
            // throw new ArgumentException("Product ID cannot be null or empty.", nameof(product.Id));
            throw new BadRequestException("Product ID cannot be null or empty.");
        }
        // update the product in the list
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct == null)
        {
            throw new NotFoundException($"Product with ID {product.Id} not found.");
        }
        // update the product properties
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
    }

    public void Delete(string id)
    {
        // check product id is not null or empty
        if (string.IsNullOrEmpty(id))
        {
            throw new BadRequestException("Product ID cannot be null or empty.");
        }
        // check fake product id 
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }
        // delete the product from the list
        _products.Remove(product);
    }
}