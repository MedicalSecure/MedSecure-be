namespace Prescription.Application.DTOs
{
    public record EquipmentDTO(Guid Id, Guid RoomId, string Name, string Reference, EqStatus EqStatus, EqType EqType);
}