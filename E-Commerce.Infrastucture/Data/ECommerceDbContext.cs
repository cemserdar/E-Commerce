using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API configurations
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Basket>()
            .HasOne(b => b.User)
            .WithMany(u => u.Baskets)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Basket>()
            .HasOne(b => b.Product)
            .WithMany()
            .HasForeignKey(b => b.ProductId);
    }
}
