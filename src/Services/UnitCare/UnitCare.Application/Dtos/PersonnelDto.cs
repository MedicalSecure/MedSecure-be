namespace UnitCare.Application.Dtos
{
    public record PersonnelDto(Guid Id, Guid UnitCareId, string Name, Shift Shift);
}
