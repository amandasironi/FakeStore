using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class CartViewModelMapper
{
    public static CartViewModel Map(Cart cart, User user, List<Product> products)
    {
        var cartViewModel = new CartViewModel
        {
            CartId = cart.Id,
            Date = cart.Date,
            User = new UserViewModel()
            {
                UserId = user.Id,
                FullName = user.Name.FirstName + " " + user.Name.LastName,
                Address = user.Address.Street + ", " + user.Address.Number + ". " + user.Address.City + ", " + user.Address.ZipCode + ".",
            },
            CartItems = cart.Products
                .Select(cartItem =>
                {
                    return CartItemViewModelMapper.Map(cartItem, products.FirstOrDefault(p => p.Id == cartItem.ProductId));
                })
                .ToList()
        };
        cartViewModel.CartPrice = cartViewModel.CartItems.Sum(p => p.TotalPrice);
        cartViewModel.DolarCartPrice = cartViewModel.CartPrice * 0.18m;

        return cartViewModel;
    }
}