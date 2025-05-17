using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using DomainDrivenDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            //TODO: connection stringi ver
            opt.UseSqlServer(configuration.GetConnectionString(""));
        });

        services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<AppDbContext>()); // Register the DbContext as IUnitOfWork

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
