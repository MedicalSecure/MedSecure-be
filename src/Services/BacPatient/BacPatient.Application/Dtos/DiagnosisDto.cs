namespace BacPatient.Application.Dtos
{
    public record DiagnosisDto(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
}