using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class NewCartViewModelMapper
{
    public static NewCartViewModel MapToViewModel(List<Product> products, List<User> users)
    {

        return new NewCartViewModel
        {
            Products = products.Select(ProductViewModelMapper.MapToViewModel).ToList(),
            Users = users.Select(UserViewModelMapper.MapToViewModel).ToList(),
            CartItems = new List<CartItemViewModel>()
        };
    }
    public static Cart MapToEntity(NewCartViewModel newCartViewModel)
    {
        return new Cart
        {
            UserId = newCartViewModel.UserId,
            Date = DateTime.Now,
            Products = newCartViewModel.CartItems
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