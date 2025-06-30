using FakeStore.Application.Interfaces;
using FakeStore.Domain.Entities;

namespace FakeStore.Application.Services;

public class CartService(IHttpService httpService) : ICartService
{
    private readonly IHttpService _httpService = httpService;

    private readonly string baseURL = "https://fakestoreapi.com/carts/";

    public async Task<List<Cart>> GetAllCarts()
    {
        return await _httpService.GetAsync<List<Cart>>(baseURL);
    }

    public async Task<Cart> GetCartById(int cartId)
    {
        return await _httpService.GetAsync<Cart>(baseURL + cartId);
    }

    public async Task<Cart> InsertCart(Cart cart)
    {
        return await _httpService.PostAsync<Cart>(baseURL, cart);
    }

    public async Task<Cart> UpdateCart(Cart cart)
    {
        return await _httpService.PutAsync<Cart>(baseURL + cart.Id, cart);
    }

    public async void DeleteCart(int cartId)
    {
        await _httpService.DeleteAsync(baseURL + cartId);
    }
}