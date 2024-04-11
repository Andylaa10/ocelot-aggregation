using InventoryService.Core.Repositories;
using InventoryService.Core.Repositories.Interfaces;
using InventoryService.Core.Services.Interfaces;

namespace InventoryService.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IInventoryService, Core.Services.InventoryService>();
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}