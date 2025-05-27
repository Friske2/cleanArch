using Microsoft.AspNetCore.Mvc;
using cleanArch.Application.Interfaces;
using cleanArch.Domain.Entities;
using cleanArch.Api.Contracts.Requests;
using cleanArch.Application.Exceptions;
using cleanArch.Application.Wrappers;
using cleanArch.api.contracts.requests;
namespace cleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_productService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var product = _productService.GetById(id);
        if (product == null)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateProductRequest product)
    {
        // validate the product data
        if (product.Name == null || product.Price <= 0)
        {
            // set status code to 400 Bad Request
            throw new BadRequestException("Invalid product data. Name cannot be null and Price must be greater than zero.");
        }

        // create a new product instance
        var payload = new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = product.Name,
            Price = product.Price
        };

        _productService.Add(payload);
        var response = new SuccessResponse<string>(payload.Id, "Product created successfully", 201);
        return StatusCode(201, response);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UpdateProductRequest product)
    {
        // validate the product data
        if (product.Name == null || product.Price <= 0)
        {
            // set status code to 400 Bad Request
            throw new BadRequestException("Invalid product data. Name cannot be null and Price must be greater than zero.");
        }

        var payload = new Product
        {
            Id = id,
            Name = product.Name,
            Price = product.Price
        };

        _productService.Update(payload);
        return Ok(new SuccessResponse<string>(id, "Product updated successfully"));
    }
}