using Xunit;
using Moq;
using System.Collections.Generic;
using cleanArch.Application.Interfaces;
using cleanArch.Infrastructure.Services;
using cleanArch.Domain.Entities;
using cleanArch.Application.Exceptions;

namespace cleanArch.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductService> _mockRepo;
    private readonly ProductService _service;


    [Fact]
    public void GetAllProduct_ShouldBeNotNull()
    {
        var products = _service.GetAll();

        Assert.NotNull(products);
    }

    [Fact]
    public void AddProductAndGetById_ShouldReturnProduct_WhenExists()
    {
        // Add a product
        var product = new Product
        {
            Id = "MOCK_UUID",
            Name = "Test Product",
            Price = 9.99m
        };
        _service.Add(product);
        // Get product by ID
        var retrievedProduct = _service.GetById("MOCK_UUID");
        Assert.NotNull(retrievedProduct);
        Assert.Equal("Test Product", retrievedProduct.Name);
    }

    [Fact]
    public void GetFakeProducts_ShouldBeNull()
    {
        var fakeProductId = "FAKE_UUID";
        var product = _service.GetById(fakeProductId);
        Assert.Null(product);
    }

    [Fact]

    public void DeleteProductAndGetById_ShouldReturnNull_WhenDeleted()
    {
        // Add a product
        var product = new Product
        {
            Id = "MOCK_UUID",
            Name = "Test Product",
            Price = 9.99m
        };
        _service.Add(product);

        // Delete the product
        _service.Delete("MOCK_UUID");

        // Try to get the deleted product
        var deletedProduct = _service.GetById("MOCK_UUID");
        Assert.Null(deletedProduct);
    }

    [Fact]
    public void UpdateProduct_ShouldBeUpdated()
    {
        // Add a product
        var product = new Product
        {
            Id = "MOCK_UUID",
            Name = "Test Product",
            Price = 9.99m
        };
        _service.Add(product);

        // Update the product
        product.Name = "Updated Product";
        _service.Update(product);

        // Get the updated product by ID
        var updatedProduct = _service.GetById("MOCK_UUID");
        Assert.NotNull(updatedProduct);
        Assert.Equal("Updated Product", updatedProduct.Name);
    }

    [Fact]
    public void UpdateFakeProduct_ShouldThrowException()
    {
        // Attempt to update a product that does not exist
        var fakeProduct = new Product
        {
            Id = "FAKE_UUID",
            Name = "Fake Product",
            Price = 19.99m
        };

        // Assert throw Product NotFoundException
        Assert.Throws<NotFoundException>(() => _service.Update(fakeProduct));
    }

}
