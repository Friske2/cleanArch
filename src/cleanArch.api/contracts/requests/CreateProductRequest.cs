namespace cleanArch.Api.Contracts.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
    }
}