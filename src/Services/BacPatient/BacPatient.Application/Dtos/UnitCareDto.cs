namespace BacPatient.Application.Dtos
{
    public record UnitCareDto(Guid Id, string Type, string Description, string Title, RoomDto Rooms, List<PersonnelDto> Personnels);
}
