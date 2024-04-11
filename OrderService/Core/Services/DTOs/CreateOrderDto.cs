namespace OrderService.Core.Services.DTOs;

public class CreateOrderDto
{
    public Dictionary<int, int> Products { get; set; } = new();
    public float TotalCost { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}