namespace E_Commerce.Domain.Models;

public class Basket
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign Key
    public User User { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign Key
    public Product Product { get; set; } // Navigation property
    public decimal TotalPrice { get; set; }
}