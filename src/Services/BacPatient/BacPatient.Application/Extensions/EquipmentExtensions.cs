
namespace BacPatient.Application.Extensions
{
    public static partial class EquipmentExtensions
    {
        public static IEnumerable<EquipmentDto> ToEquipmentDto(this List<Equipment> equipments)
        {
            return equipments.Select(e => new EquipmentDto(
                                Id: e.Id.Value,
                                RoomId: e.RoomId.Value,
                                Name: e.Name,
                                Reference: e.Reference
                               ));
        }
        public static EquipmentDto ToEquipmentDto(this Equipment equipment)
        {
            return new EquipmentDto(
                Id: equipment.Id.Value,
                RoomId: equipment.RoomId.Value,
                Name: equipment.Name,
                Reference: equipment.Reference
            );
        }

        // Convert a single EquipmentDto to EquipmentEntity
        public static Equipment ToEquipmentEntity(this EquipmentDto dto)
        {
            return new Equipment(
                Id: EquipmentId.Of(dto.Id),
                RoomId: dto.RoomId,
                Name: dto.Name,
                Reference: dto.Reference
            );
        }
    }
}
