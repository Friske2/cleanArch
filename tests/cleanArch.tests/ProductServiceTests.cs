using Xunit;
using Moq;
using System.Collections.Generic;
using cleanArch.Application.Interfaces;
using cleanArch.Infrastructure.Services;
using cleanArch.Domain.Entities;

namespace cleanArch.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductService> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductService>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { Id = "1", Name = "Pen", Price = 10 },
            new Product { Id = "2", Name = "Notebook", Price = 50 }
        };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(products);

        // Act
        var result = _service.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
    }

}
