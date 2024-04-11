using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Core.Services.DTOs;
using ProductCatalogService.Core.Services.Interfaces;

namespace ProductCatalogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCatalogController : ControllerBase
{
    private readonly IProductCatalogService _productCatalogService;

    public ProductCatalogController(IProductCatalogService productCatalogService)
    {
        _productCatalogService = productCatalogService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductCatalog([FromBody] CreateProductCatalogDto dto)
    {
        try
        {
            await _productCatalogService.CreateProductCatalog(dto);
            return StatusCode(201, "Product Catalog successfully created");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ProductCatalog()
    {
        try
        {
            return Ok(await _productCatalogService.ProductCatalogs());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductCatalogById([FromRoute] int id)
    {
        try
        {
            return Ok(await _productCatalogService.GetProductCatalogById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProductCatalog([FromRoute] int id, [FromBody] UpdateProductCatalogDto dto)
    {
        try
        {
            await _productCatalogService.UpdateProductCatalog(id, dto);
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
    public async Task<IActionResult> DeleteProductCatalog([FromRoute] int id)
    {
        try
        {
            await _productCatalogService.DeleteProductCatalog(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}