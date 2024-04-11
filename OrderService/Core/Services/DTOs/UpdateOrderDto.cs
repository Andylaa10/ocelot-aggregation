namespace OrderService.Core.Services.DTOs;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public Dictionary<int, int> Products { get; set; } = new();
    public float TotalCost { get; set; } = 0;
    public DateTime? UpdatedAt { get; set; }
}