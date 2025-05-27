using cleanArch.Domain.Entities;

namespace cleanArch.Application.Interfaces;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(string id);
    void Add(Product product);
    void Update(Product product);
    void Delete(string id);
}