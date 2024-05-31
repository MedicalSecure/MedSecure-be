namespace Prescription.Application.DTOs
{
    public record RoomDTO(Guid Id, Guid UnitCareId, decimal RoomNumber, Status Status, List<EquipmentDTO> Equipments);
}