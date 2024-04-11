using ProductCatalogService.Core.Repositories;
using ProductCatalogService.Core.Repositories.Interfaces;
using ProductCatalogService.Core.Services.Interfaces;

namespace ProductCatalogService.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProductCatalogRepository, ProductCatalogRepository>();
        services.AddScoped<IProductCatalogService, Core.Services.ProductCatalogService>();
        services.AddSingleton(AutoMapperConfig.ConfigureAutoMapper());
    }
}