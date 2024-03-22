
namespace Waste.Application.Wastes.Queries.GetWasteByRoomIdQuery
{
    public record GetWasteByRoomIdQuery(Guid id) : IQuery<GetWasteByRoomIdResult>;

    public record GetWasteByRoomIdResult(IEnumerable<WasteDto> Wastes);
   
}
