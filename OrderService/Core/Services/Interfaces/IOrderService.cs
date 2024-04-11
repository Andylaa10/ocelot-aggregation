using OrderService.Core.Entities;
using OrderService.Core.Services.DTOs;

namespace OrderService.Core.Services.Interfaces;

public interface IOrderService
{
    public Task CreateOrder(CreateOrderDto order);
    public Task<IEnumerable<Order>> Orders();
    public Task<Order> GetOrderById(int id);
    public Task UpdateOrder(int id, UpdateOrderDto order);
    public Task DeleteOrder(int id);
}