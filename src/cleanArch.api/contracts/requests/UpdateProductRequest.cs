using System;

namespace cleanArch.api.contracts.requests;

public class UpdateProductRequest
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
}
