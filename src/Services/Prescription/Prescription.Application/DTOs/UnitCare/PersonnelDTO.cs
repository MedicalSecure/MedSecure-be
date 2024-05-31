namespace Prescription.Application.DTOs
{
    public record PersonnelDTO(Guid Id, Guid UnitCareId, string Name, Shift Shift, Gender Gender);
}