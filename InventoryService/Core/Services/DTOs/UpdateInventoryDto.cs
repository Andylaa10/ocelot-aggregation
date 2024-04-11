namespace InventoryService.Core.Services.DTOs;

public class UpdateInventoryDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public DateTime? UpdateAt { get; set; }
}