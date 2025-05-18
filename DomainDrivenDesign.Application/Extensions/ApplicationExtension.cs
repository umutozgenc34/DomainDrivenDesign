using DomainDrivenDesign.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesign.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationExtension(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
                typeof(Entity).Assembly);
        });
        return services;
    }
}
