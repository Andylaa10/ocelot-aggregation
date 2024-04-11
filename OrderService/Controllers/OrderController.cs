using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Services.DTOs;
using OrderService.Core.Services.Interfaces;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
    {
        try
        {
            await _orderService.CreateOrder(dto);
            return StatusCode(201, "Order successfully created");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        try
        {
            return Ok(await _orderService.Orders());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        try
        {
            return Ok(await _orderService.GetOrderById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderDto dto)
    {
        try
        {
            await _orderService.UpdateOrder(id, dto);
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
    public async Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        try
        {
            await _orderService.DeleteOrder(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}