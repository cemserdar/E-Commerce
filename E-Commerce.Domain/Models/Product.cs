namespace E_Commerce.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; } // Foreign Key
    public Category Category { get; set; } // Navigation property
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}