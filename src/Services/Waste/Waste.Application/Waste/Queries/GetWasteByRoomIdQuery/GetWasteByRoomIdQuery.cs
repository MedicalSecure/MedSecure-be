
namespace Waste.Application.Wastes.Queries.GetWasteByRoomIdQuery
{
    public record RoomByNameQuery(Guid id) : IQuery<GetWasteByRoomIdResult>;

    public record GetWasteByRoomIdResult(IEnumerable<WasteDto> Wastes);
   
}
