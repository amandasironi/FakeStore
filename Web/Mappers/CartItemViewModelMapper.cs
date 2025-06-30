using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class CartItemViewModelMapper
{
    public static CartItemViewModel Map(CartItem cartItem, Product product)
    {
        return new CartItemViewModel
            {
                ProductId = product.Id,
                ProductTitle = product?.Title,
                Quantity = cartItem.Quantity,
                UnitPrice = product?.Price ?? 0,
                TotalPrice = (product?.Price ?? 0) * cartItem.Quantity,
                ImageUrl = product?.Image
            };
    }
}