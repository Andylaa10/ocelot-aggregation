using AutoMapper;
using ProductCatalogService.Core.Entities;
using ProductCatalogService.Core.Services.DTOs;

namespace ProductCatalogService.Configs;

public static class AutoMapperConfig
{
    public static IMapper ConfigureAutoMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            //DTO to Entity
            config.CreateMap<CreateProductCatalogDto, ProductCatalog>();
            config.CreateMap<UpdateProductCatalogDto, ProductCatalog>();

        }).CreateMapper();

        return mapperConfig;
    }
}