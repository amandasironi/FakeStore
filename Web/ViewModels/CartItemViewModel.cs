namespace FakeStore.Web.ViewModels;

public class CartItemViewModel
{
    public int ProductId { get; set; } //
    public string ProductTitle { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string ImageUrl { get; set; }
}