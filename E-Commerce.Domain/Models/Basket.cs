using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Models;

public class Basket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
}