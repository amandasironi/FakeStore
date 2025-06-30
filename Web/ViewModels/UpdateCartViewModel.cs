namespace FakeStore.Web.ViewModels;

public class UpdateCartViewModel
{
    public List<ProductViewModel> Products { get; set; }
    public List<UserViewModel> Users { get; set; }
    public CartViewModel Cart { get; set; }
}