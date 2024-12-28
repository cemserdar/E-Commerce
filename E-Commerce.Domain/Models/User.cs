using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Role { get; set; }
    public string Address { get; set; }
    public string Telefon { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Basket> Baskets { get; set; } 
}