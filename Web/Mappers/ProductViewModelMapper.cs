using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class ProductViewModelMapper
{
    public static ProductViewModel MapToViewModel(Product product)
    {
        return new ProductViewModel()
            {
                ProductId = product.Id,
                ProductTitle = product.Title,
                UnitPrice = product.Price,
                ImageUrl = product.Image,
            };
    }
}