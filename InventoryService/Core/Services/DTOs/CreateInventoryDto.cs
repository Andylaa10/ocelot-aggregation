namespace InventoryService.Core.Services.DTOs;

public class CreateInventoryDto
{
    public int ProductId { get; set; }
    public int Count { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}