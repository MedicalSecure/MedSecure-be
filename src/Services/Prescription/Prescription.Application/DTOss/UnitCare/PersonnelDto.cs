namespace Prescription.Application.DTOs
{
    public record PersonnelDto(Guid Id, Guid UnitCareId, string Name, Shift Shift, Gender Gender);
}