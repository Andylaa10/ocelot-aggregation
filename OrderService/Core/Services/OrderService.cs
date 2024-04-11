using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Core.Repositories.Interfaces;
using OrderService.Core.Services.DTOs;
using OrderService.Core.Services.Interfaces;

namespace OrderService.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task CreateOrder(CreateOrderDto order)
    {
        await _orderRepository.CreateOrder(_mapper.Map<Order>(order));
    }

    public async Task<IEnumerable<Order>> Orders()
    {
        return await _orderRepository.Orders();
    }

    public async Task<Order> GetOrderById(int id)
    {
        if (id < 1) throw new ArgumentException("Id cannot be less 1");

        return await _orderRepository.GetOrderById(id) ?? throw new ArgumentException($"No order with the id of {id}");
    }

    public async Task UpdateOrder(int id, UpdateOrderDto order)
    {
        var update = await _orderRepository.DoesOrderExist(id);
        if (id < 1) throw new ArgumentException("Id cannot be less 1");
        if (!update) throw new ArgumentException($"No such order with the id of {id}");
        if (id != order.Id) throw new ArgumentException("Id in the route does not match with the order id");

        await _orderRepository.UpdateOrder(id, _mapper.Map<Order>(order));
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _orderRepository.DoesOrderExist(id);
        if (!order) throw new ArgumentException($"No such order with the id of {id}");
        if (id < 1) throw new ArgumentException("Id cannot be less than 1");

        await _orderRepository.DeleteOrder(id);
    }
}