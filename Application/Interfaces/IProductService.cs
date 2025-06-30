using FakeStore.Domain.Entities;

namespace FakeStore.Application.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetAllProducts();
    public Task<Product> GetProductById(int productId);
    public Task<Product> InsertProduct(Product product);
    public Task<Product> UpdateProduct(Product product);
    public void DeleteProduct(int productId);
}