namespace Waste.Domain.Models;

public class WasteItem : Entity<WasteItemId>
{
    public WasteId WasteId { get; set; } = default!;
    public ProductId ProductId { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public decimal Weight { get; set; } = default!;

    public WasteItem(WasteId wasteId, ProductId productId, int quantity, decimal weight)
    {
        Id = WasteItemId.Of(Guid.NewGuid());
        WasteId = wasteId;
        ProductId = productId;
        Quantity = quantity;
        Weight = weight;
    }
}