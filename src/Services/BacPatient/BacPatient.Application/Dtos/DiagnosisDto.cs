namespace BacPatient.Application.DTOs
{
    public record DiagnosisDto(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
}