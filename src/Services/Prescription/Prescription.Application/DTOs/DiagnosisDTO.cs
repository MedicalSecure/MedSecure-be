namespace Prescription.Application.DTOs
{
    public record DiagnosisDTO(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
}