namespace ProductCatalogService.Core.Entities;

public class ProductCatalog
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public float Cost { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public ProductCatalog()
    {
        Id = _nextId++;
    }
}