namespace Prescription.Application.DTOs
{
    public record EquipmentDto(Guid Id, Guid RoomId, string Name, string Reference, EqStatus EqStatus);
}