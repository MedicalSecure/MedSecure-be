

namespace Waste.Application.Extensions;

public static partial class WasteExtensions
{
    public static IEnumerable<WasteDto> ToWasteDto(this List<Domain.Models.Waste> wastes)
    {
        return wastes.Select(w => new WasteDto(
            Id: w.Id.Value,
            RoomId: w.RoomId.Value,
            PickupLocation: new AddressDto(
                Street: w.PickupLocation.Street,
                City: w.PickupLocation.City,
                State: w.PickupLocation.State,
                ZipCode: w.PickupLocation.ZipCode,
                Country: w.PickupLocation.Country,
                Phone: w.PickupLocation.Phone,
                Email: w.PickupLocation.Email),
            DropOffLocation: new AddressDto(
                Street: w.DropOffLocation.Street,
                City: w.DropOffLocation.City,
                State: w.DropOffLocation.State,
                ZipCode: w.DropOffLocation.ZipCode,
                Country: w.DropOffLocation.Country,
                Phone: w.DropOffLocation.Phone,
                Email: w.DropOffLocation.Email),
            Status: w.Status,
            Color: w.Color,
            WasteItems: w.WasteItems.Select(wi => new WasteItemDto(
                Id: wi.Id.Value,
                WasteId: wi.WasteId.Value,
                ProductId: wi.ProductId.Value,
                Quantity: wi.Quantity,
                Weight: wi.Weight))
                .ToList()))
            .ToList();
    }
}
