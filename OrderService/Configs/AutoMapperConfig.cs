using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Core.Services.DTOs;

namespace OrderService.Configs;

public static class AutoMapperConfig
{
    public static IMapper ConfigureAutoMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            //DTO to Entity
            config.CreateMap<CreateOrderDto, Order>();
            config.CreateMap<UpdateOrderDto, Order>();

        }).CreateMapper();

        return mapperConfig;
    }
}