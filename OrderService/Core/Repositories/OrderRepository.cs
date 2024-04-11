using OrderService.Core.Entities;
using OrderService.Core.Repositories.Interfaces;

namespace OrderService.Core.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new()
    {
        new Order
        {
            Products = new Dictionary<int, int>()
            {
                //first int represent productId and the second int represent the count
                { 1, 5 }
            },
            TotalCost = 500.0f,
            CreatedAt = DateTime.Now
        },
        new Order
        {
            Products = new Dictionary<int, int>()
            {
                //first int represent productId and the second int represent the count
                { 2, 1 }
            },
            TotalCost = 50.0f,
            CreatedAt = DateTime.Now.AddHours(1)
        },
        new Order
        {
            Products = new Dictionary<int, int>()
            {
                //first int represent productId and the second int represent the count
                { 3, 2 }
            },
            TotalCost = 75.0f,
            CreatedAt = DateTime.Now.AddHours(2)
        },
        new Order
        {
            Products = new Dictionary<int, int>()
            {
                //first int represent productId and the second int represent the count
                { 4, 4 }
            },
            TotalCost = 1000.0f,
            CreatedAt = DateTime.Now.AddHours(3)
        },
        new Order
        {
            Products = new Dictionary<int, int>()
            {
                //first int represent productId and the second int represent the count
                { 5, 3 }
            },
            TotalCost = 1500.0f,
            CreatedAt = DateTime.Now.AddHours(4)
        }
    };

    public async Task CreateOrder(Order order)
    {
        await Task.Run(() => { _orders.Add(order); });
    }

    public async Task<IEnumerable<Order>> Orders()
    {
        return await Task.Run(() => _orders.AsQueryable());
    }

    public async Task<Order> GetOrderById(int id)
    {
        var order = _orders.Find(o => o.Id == id) ?? throw new ArgumentException($"No order with the id of {id}");
        
        return await Task.FromResult(order);
    }

    public async Task UpdateOrder(int id, Order order)
    {
        var updateOrder = _orders.Find(o => o.Id == id) ?? throw new ArgumentException($"No order with the id of {id}");

        await Task.Run(() =>
        {
            updateOrder.Products = order.Products;
            updateOrder.UpdatedAt = DateTime.Now;
            updateOrder.TotalCost = order.TotalCost;
        });
    }

    public async Task DeleteOrder(int id)
    {
        var order = _orders.Find(o => o.Id == id) ?? throw new ArgumentException($"No order with the id of {id}");

        var index = _orders.IndexOf(order);
        
        await Task.Run(()=> _orders.RemoveAt(index));
    }

    public async Task<bool> DoesOrderExist(int id)
    {
        var order = _orders.Find(o => o.Id == id);

        if (order == null) await Task.Run(() => false);
        return await Task.Run(() => true);
    }
}