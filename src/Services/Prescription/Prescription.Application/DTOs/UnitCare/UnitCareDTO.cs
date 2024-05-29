namespace Prescription.Application.DTOs
{
    public record UnitCareDTO(Guid Id, string Type, string Description, string Title, List<RoomDTO> Rooms, List<PersonnelDTO> Personnels);
}