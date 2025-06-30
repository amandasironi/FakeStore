using FakeStore.Application.Interfaces;
using FakeStore.Domain.Entities;
using FakeStore.Web.Mappers;
using FakeStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FakeStore.Web.Controllers;

public class HomeController(ICartService cartService, IProductService productService, IUserService userService) : Controller
{
    private readonly ICartService _cartService = cartService;
    private readonly IProductService _productService = productService;
    private readonly IUserService _userService = userService;

    public async Task<IActionResult> Index()
    {
        var carts = await _cartService.GetAllCarts();
        var users = await _userService.GetAllUsers();
        var products = await _productService.GetAllProducts();

        var cartViewModels = carts
            .Select(cart => CartViewModelMapper.Map(
                cart,
                users.Find(user => user.Id == cart.UserId),
                products
            )).ToList();

        return View(cartViewModels);
    }

    public async Task<IActionResult> Create()
    {
        var products = await _productService.GetAllProducts();
        var users = await _userService.GetAllUsers();

        return View(NewCartViewModelMapper.MapToViewModel(products, users));
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewCartViewModel newCartViewModel)
    {
        var cart = NewCartViewModelMapper.MapToEntity(newCartViewModel);
        cart.Id = (await _cartService.InsertCart(cart)).Id;

        var user = await _userService.GetUserById(cart.UserId);
        var products = await _productService.GetAllProducts();

        CartViewModel cartViewModel = CartViewModelMapper.Map(cart, user, products);

        return View("Report", cartViewModel);
    }

    public async Task<IActionResult> Update(int id)
    {
        Cart cart = await _cartService.GetCartById(id);
        var users = await _userService.GetAllUsers();
        var products = await _productService.GetAllProducts();

        UpdateCartViewModel updateCartViewModel = UpdateCartViewModelMapper.MapToViewModel(cart, products, users);

        return View("Edit", updateCartViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCartViewModel updateCartViewModel)
    {
        var cart = UpdateCartViewModelMapper.MapToEntity(updateCartViewModel);

        await _cartService.UpdateCart(cart);
        
        var user = await _userService.GetUserById(cart.UserId);
        var products = await _productService.GetAllProducts();
        var cartViewModel = CartViewModelMapper.Map(cart, user, products);

        return View("Report", cartViewModel);
    }

    public IActionResult Report(CartViewModel cartViewModel)
    {
        return View(cartViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
