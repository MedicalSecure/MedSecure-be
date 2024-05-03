namespace Prescription.Application.DTOs
{
    public record RoomDto(Guid Id, Guid UnitCareId, decimal RoomNumber, Status Status, List<EquipmentDto> Equipments);
}