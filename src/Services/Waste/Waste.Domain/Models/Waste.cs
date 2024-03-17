namespace Waste.Domain.Models;

public class Waste : Aggregate<WasteId>
{
    private readonly List<WasteItem> _wasteItems = new();

    public IReadOnlyList<WasteItem> WasteItems => _wasteItems.AsReadOnly();

    public RoomId RoomId { get; set; } = default!;

    public Address PickupLocation { get; private set; } = default!;

    public Address DropOffLocation { get; private set; } = default!;

    public WasteStatus Status { get; private set; } = WasteStatus.Pending;

    public WasteColor Color { get; private set; } = WasteColor.Black;

    public decimal TotalWeight
    {
        get => WasteItems.Sum(x => x.Weight * x.Quntity);
        private set { }
    }

    public static Waste Create(
        WasteId id,
        RoomId roomId,
        Address pickupLocation,
        Address dropOffLocation,
        WasteStatus status,
        WasteColor color)
    {
        var waste = new Waste()
        {
            Id = id,
            RoomId = roomId,
            PickupLocation = pickupLocation,
            DropOffLocation = dropOffLocation,
            Status = status,
            Color = color,
        };

        waste.AddDomainEvent(new WasteCreatedEvent(waste));

        return waste;
    }

    public void Update(
        RoomId roomId,
        Address pickupLocation,
        Address dropOffLocation,
        WasteStatus status,
        WasteColor color)
    {
        RoomId = roomId;
        PickupLocation = pickupLocation;
        DropOffLocation = dropOffLocation;
        Status = status;
        Color = color;

        AddDomainEvent(new WasteUpdatedEvent(this));
    }

    public void AddItem(WasteId wasteId, ProductId productId, int quantity, decimal weight)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight);

        var wasteItem = new WasteItem(wasteId, productId, quantity, weight);
        _wasteItems.Add(wasteItem);
    }

    public void RemoveItem(ProductId productId)
    {
        var wasteItem = _wasteItems.FirstOrDefault(p => p.ProductId == productId);
        if (wasteItem != null)
        {
            _wasteItems.Remove(wasteItem);
        }
    }
}