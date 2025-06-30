using System.Text.Json;

namespace FakeStore.Domain.Entities;

public class Cart 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public required List<CartItem> Products { get; set; }
}