using InventoryService.Core.Services.DTOs;
using InventoryService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryDto dto)
    {
        try
        {
            await _inventoryService.CreateInventory(dto);
            return StatusCode(201, "Inventory successfully created");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Inventories()
    {
        try
        {
            return Ok(await _inventoryService.Inventories());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{productId}")]
    public async Task<IActionResult> GetInventoryById([FromRoute] int productId)
    {
        try
        {
            return Ok(await _inventoryService.GetInventoryByProductId(productId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateInventory([FromRoute] int id, [FromBody] UpdateInventoryDto dto)
    {
        try
        {
            await _inventoryService.UpdateInventory(id, dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInventory([FromRoute] int id)
    {
        try
        {
            await _inventoryService.DeleteInventory(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}