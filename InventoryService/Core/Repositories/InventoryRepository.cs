using InventoryService.Core.Entities;
using InventoryService.Core.Repositories.Interfaces;

namespace InventoryService.Core.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private static readonly List<Inventory> _inventories = new()
    {
        new Inventory
        {
            ProductId = 1,
            Count = 3,
            CreatedAt = DateTime.Now
        },
        new Inventory
        {
            ProductId = 2,
            Count = 5,
            CreatedAt = DateTime.Now.AddHours(1)
        },
        new Inventory
        {
            ProductId = 3,
            Count = 2,
            CreatedAt = DateTime.Now.AddHours(2)
        },
        new Inventory
        {
            ProductId = 4,
            Count = 11,
            CreatedAt = DateTime.Now.AddHours(3)
        },
        new Inventory
        {
            ProductId = 5,
            Count = 1,
            CreatedAt = DateTime.Now.AddHours(4)
        },
    };

    public async Task CreateInventory(Inventory inventory)
    {
        await Task.Run(() => { _inventories.Add(inventory); });
    }

    public async Task<IEnumerable<Inventory>> Inventories()
    {
        return await Task.Run(() => _inventories);
    }

    public async Task<Inventory> GetInventoryByProductId(int productId)
    {
        var inventory = _inventories.Find(i => i.ProductId == productId) 
                        ?? throw new ArgumentException($"No inventory with the id of {productId}");
        return await Task.FromResult(inventory);
    }

    public async Task UpdateInventory(int id, Inventory inventory)
    {
        var updateInventory = _inventories.Find(i => i.Id == id) 
                              ?? throw new ArgumentException($"No inventory with the id of {id}");
        await Task.Run(() =>
        {
            updateInventory.Count = inventory.Count;
            updateInventory.UpdatedAt = DateTime.Now;
        });
    }

    public async Task DeleteInventory(int id)
    {
        var inventory = _inventories.Find(i => i.Id == id) 
                        ?? throw new ArgumentException($"No inventory with the id of {id}");
        
        var index = _inventories.IndexOf(inventory);
        await Task.Run(() => { _inventories.RemoveAt(index); });
    }

    public Task<bool> DoesInventoryExist(int id)
    {
        var inventory = _inventories.Find(i => i.Id == id);

        if (inventory is null) return Task.Run(() => false);
        return Task.Run(() => true);
    }
}