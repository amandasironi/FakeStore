using FakeStore.Domain.Entities;

namespace FakeStore.Application.Interfaces;

public interface ICartService
{
    public Task<List<Cart>> GetAllCarts();
    public Task<Cart> GetCartById(int cartId);
    public Task<Cart> InsertCart(Cart cart);
    public Task<Cart> UpdateCart(Cart cart);
    public void DeleteCart(int cartId);
}