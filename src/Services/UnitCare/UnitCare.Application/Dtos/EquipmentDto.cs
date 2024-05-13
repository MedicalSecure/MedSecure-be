namespace UnitCare.Application.Dtos
{
    public record EquipmentDto(Guid Id, Guid RoomId, string Name, string Reference, EqStatus EqStatus, EqType EqType);
}
