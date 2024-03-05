using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThunderWings.Application.Data;
using ThunderWings.Application.Orders;
using ThunderWings.Application.Products;
using ThunderWings.Domain.Orders;
using ThunderWings.Domain.Products;
using ThunderWings.Infrastructure.Repositories;
using ThunderWings.Infrastructure.Services;

namespace ThunderWings.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
        sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IOrderReadService, OrderReadService>();

        services.AddScoped<IProductReadService, ProductReadService>();

        return services;
    }
}
