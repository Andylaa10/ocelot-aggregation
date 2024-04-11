using AutoMapper;
using InventoryService.Core.Entities;
using InventoryService.Core.Services.DTOs;


namespace InventoryService.Configs;

public static class AutoMapperConfig
{
    public static IMapper ConfigureAutoMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            //DTO to Entity
            config.CreateMap<CreateInventoryDto, Inventory>();
            config.CreateMap<UpdateInventoryDto, Inventory>();
            
        }).CreateMapper();
        
        return mapperConfig;
    }
}