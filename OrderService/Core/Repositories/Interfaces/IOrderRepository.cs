using OrderService.Core.Entities;

namespace OrderService.Core.Repositories.Interfaces;

public interface IOrderRepository
{
    public Task CreateOrder(Order order);
    public Task<IEnumerable<Order>> Orders();
    public Task<Order> GetOrderById(int id);
    public Task UpdateOrder(int id, Order order);
    public Task DeleteOrder(int id);
    public Task<bool> DoesOrderExist(int id);
}