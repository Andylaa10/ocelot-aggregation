using InventoryService.Core.Entities;
using InventoryService.Core.Services.DTOs;

namespace InventoryService.Core.Services.Interfaces;

public interface IInventoryService
{
    public Task CreateInventory(CreateInventoryDto inventory);
    public Task<IEnumerable<Inventory>> Inventories();
    public Task<Inventory> GetInventoryByProductId(int productId);
    public Task UpdateInventory(int id, UpdateInventoryDto inventory);
    public Task DeleteInventory(int id);
}