namespace Waste.Domain.Models;

public class WasteItem : Entity<WasteItemId>
{
    public WasteItem(WasteId wasteId, ProductId productId, int quntity, decimal weight)
    {
        Id = WasteItemId.Of(Guid.NewGuid());
        WasteId = wasteId;
        ProductId = productId;
        Quntity = quntity;
        Weight = weight;
    }

    public WasteId WasteId { get; set; } = default!;
    public ProductId ProductId { get; set; } = default!;
    public int Quntity { get; set; } = default!;
    public decimal Weight { get; set; } = default!;

}