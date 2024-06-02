namespace UnitCare.Application.Dtos
{
    public record UnitCareDto(Guid Id, string Type, string Description, string Title, UnitStatus UnitStatus, List<RoomDto> Rooms, List<PersonnelDto> Personnels);
}
