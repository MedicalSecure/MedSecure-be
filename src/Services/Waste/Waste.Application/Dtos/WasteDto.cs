
namespace Waste.Application.Dtos;

public record WasteDto(Guid Id, Guid RoomId, AddressDto PickupLocation, AddressDto DropOffLocation, WasteStatus Status, WasteColor Color, List<WasteItemDto> WasteItems);
