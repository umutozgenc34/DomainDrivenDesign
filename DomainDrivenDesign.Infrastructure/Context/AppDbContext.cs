using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DomainDrivenDesign.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) , IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
           .Property(p => p.Name)
           .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Email)
           .HasConversion(email => email.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Password)
           .HasConversion(password => password.Value, value => new(value));

        modelBuilder.Entity<User>()
            .OwnsOne(p => p.Address);

        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });

        modelBuilder.Entity<OrderLine>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });
    }
}
