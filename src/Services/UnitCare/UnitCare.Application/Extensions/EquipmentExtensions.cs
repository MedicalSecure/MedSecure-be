using UnitCare.Application.Dtos;
using UnitCare.Domain.Models;

namespace UnitCare.Application.Extensions
{
    public static partial class EquipmentExtensions
    {
        public static IEnumerable<EquipmentDto> ToEquipmentDto(this List<Equipment> equipments)
        {
            return equipments.Select(e => new EquipmentDto(
                                Id: e.Id.Value,
                                RoomId: e.RoomId.Value,
                                Name: e.Name,
                                Reference: e.Reference,
                                EqStatus:e.EqStatus,
                                EqType:e.EqType
                               ));
        }
    }
}
