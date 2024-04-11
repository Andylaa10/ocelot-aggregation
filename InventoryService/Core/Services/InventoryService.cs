using AutoMapper;
using InventoryService.Core.Entities;
using InventoryService.Core.Repositories.Interfaces;
using InventoryService.Core.Services.DTOs;
using InventoryService.Core.Services.Interfaces;

namespace InventoryService.Core.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public async Task CreateInventory(CreateInventoryDto inventory)
    {
        await _inventoryRepository.CreateInventory(_mapper.Map<Inventory>(inventory));
    }

    public async Task<IEnumerable<Inventory>> Inventories()
    {
        return await _inventoryRepository.Inventories();
    }

    public async Task<Inventory> GetInventoryByProductId(int productId)
    {
        if (productId < 1) throw new ArgumentException("Id cannot be less 1");
        return await _inventoryRepository.GetInventoryByProductId(productId)
            ?? throw new ArgumentException($"No such inventory with the id of {productId}");
    }

    public async Task UpdateInventory(int id, UpdateInventoryDto updateInventory)
    {
        var inventory = await _inventoryRepository.DoesInventoryExist(id);
        if (id < 1) throw new ArgumentException("Id cannot be less than 1");
        if (id != updateInventory.Id) throw new ArgumentException("Id in the route does not match with the inventory id");
        
        if(!inventory) throw new ArgumentException($"No such inventory with the id of {id}");
        await _inventoryRepository.UpdateInventory(id, _mapper.Map<Inventory>(updateInventory));

    }

    public async Task DeleteInventory(int id)
    {
        var inventory = await _inventoryRepository.DoesInventoryExist(id);
        if (!inventory) throw new ArgumentException($"No such inventory with the id of {id}");
        if (id < 1) throw new ArgumentException("Id cannot be less than 1");
        
        await _inventoryRepository.DeleteInventory(id);
    }
}