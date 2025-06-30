using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class UpdateCartViewModelMapper
{
    public static UpdateCartViewModel MapToViewModel(Cart cart, List<Product> products, List<User> users)
    {
        return new UpdateCartViewModel
        {
            Products = products.Select(ProductViewModelMapper.MapToViewModel).ToList(),
            Users = users.Select(UserViewModelMapper.MapToViewModel).ToList(),
            Cart = CartViewModelMapper.Map(cart, users.Find(u => u.Id == cart.UserId), products),
        };
    }
    public static Cart MapToEntity(UpdateCartViewModel updateCartViewModel)
    {
        return new Cart
        {
            Id = updateCartViewModel.Cart.CartId,
            UserId = updateCartViewModel.Cart.User.UserId,
            Products = updateCartViewModel.Cart.CartItems
                .Select(cartItem =>
                    new CartItem
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity
                    }
                ).ToList()
        };
    }
}