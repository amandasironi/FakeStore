namespace FakeStore.Web.ViewModels;

public class CartViewModel
{
    public int CartId { get; set; }
    public DateTime Date { get; set; }
    public UserViewModel User { get; set; }
    public List<CartItemViewModel> CartItems { get; set; }
    public decimal CartPrice { get; set; }
    public decimal DolarCartPrice { get; set; }
}