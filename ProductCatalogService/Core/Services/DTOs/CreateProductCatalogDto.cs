namespace ProductCatalogService.Core.Services.DTOs;

public class CreateProductCatalogDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public float Cost { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}