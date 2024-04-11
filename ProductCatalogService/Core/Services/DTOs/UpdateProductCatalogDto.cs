namespace ProductCatalogService.Core.Services.DTOs;

public class UpdateProductCatalogDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public float Cost { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}