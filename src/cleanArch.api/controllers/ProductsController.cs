using Microsoft.AspNetCore.Mvc;
using cleanArch.Application.Interfaces;
using cleanArch.Domain.Entities;
using cleanArch.Api.Contracts.Requests;

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
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateProductRequest product)
    {
        try
        {
            // validate the product data
            if (product.Name == null || product.Price <= 0)
            {
                // set status code to 400 Bad Request
                return StatusCode(400, new
                {
                    Status = "Error",
                    Message = "Invalid product data. Name cannot be null and Price must be greater than zero."
                });
            }

            // create a new product instance
            var payload = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = product.Name,
                Price = product.Price
            };

            _productService.Add(payload);
            return CreatedAtAction(nameof(GetById), new { id = payload.Id }, payload);
        }
        catch (Exception ex)
        {
            // response error json format
            var errorResponse = new
            {
                Status = "Error",
                Message = $"An error occurred while creating the product: {ex.Message}"
            };

            // Log the exception
            // return json error response 
            return StatusCode(500, errorResponse);
        }
    }
}