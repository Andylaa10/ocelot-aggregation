namespace InventoryService.Core.Entities;

public class Inventory
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Inventory()
    {
        Id = _nextId++;
    }
}