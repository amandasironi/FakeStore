namespace FakeStore.Web.ViewModels;

public class NewCartViewModel
{
    public List<ProductViewModel> Products { get; set; }
    public List<UserViewModel> Users { get; set; }
    public int UserId { get; set; }
    public List<CartItemViewModel> CartItems { get; set; }
}