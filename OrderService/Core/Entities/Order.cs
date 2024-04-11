namespace OrderService.Core.Entities;

public class Order
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public Dictionary<int, int> Products { get; set; } = new();
    public float TotalCost { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public Order()
    {
        Id = _nextId++;
    }
}