using FakeStore.Domain.Entities;
using FakeStore.Application.Interfaces;

namespace FakeStore.Application.Services;

public class ProductService(IHttpService httpService) : IProductService
{
    private readonly string baseURL = "https://fakestoreapi.com/products/";
    private readonly IHttpService _httpService = httpService;

    public async Task<List<Product>> GetAllProducts()
    {
        return await _httpService.GetAsync<List<Product>>(baseURL);
    }

    public async Task<Product> GetProductById(int productId)
    {
        return await _httpService.GetAsync<Product>(baseURL + productId);
    }

    public async Task<Product> InsertProduct(Product product)
    {
        return await _httpService.PostAsync<Product>(baseURL, product);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        return await _httpService.PutAsync<Product>(baseURL, product);
    }

    public async void DeleteProduct(int productId)
    {
        await _httpService.DeleteAsync(baseURL + productId);
    }
}