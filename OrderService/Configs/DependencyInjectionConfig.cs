using OrderService.Core.Repositories;
using OrderService.Core.Repositories.Interfaces;
using OrderService.Core.Services.Interfaces;

namespace OrderService.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, Core.Services.OrderService>();
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}