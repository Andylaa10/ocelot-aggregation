using InventoryService.Core.Entities;

namespace InventoryService.Core.Repositories.Interfaces;

public interface IInventoryRepository
{
    public Task CreateInventory(Inventory inventory);
    public Task<IEnumerable<Inventory>> Inventories();
    public Task<Inventory> GetInventoryByProductId(int productId);
    public Task UpdateInventory(int id, Inventory inventory);
    public Task DeleteInventory(int id);
    public Task<bool> DoesInventoryExist(int id);
}