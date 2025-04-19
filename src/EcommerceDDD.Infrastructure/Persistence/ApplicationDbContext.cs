using EcommerceDDD.Domain.Entities.Customers;
using EcommerceDDD.Domain.Entities.Orders;
using EcommerceDDD.Domain.Entities.Products;
using EcommerceDDD.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDDD.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product configuration
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Customer configuration
        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.ShippingAddress);
        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.BillingAddress);

        // Order configuration
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .OwnsOne(o => o.ShippingAddress);
        modelBuilder.Entity<Order>()
            .OwnsOne(o => o.BillingAddress);
        modelBuilder.Entity<Order>()
            .OwnsOne(o => o.TotalAmount);

        // OrderItem configuration
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderItem>()
            .OwnsOne(oi => oi.UnitPrice);
        modelBuilder.Entity<OrderItem>()
            .OwnsOne(oi => oi.Subtotal);
    }
} 