

namespace BacPatient.Application.Extensions
{
    public static class DiagnosisExtension
    {
        public static ICollection<DiagnosisDto> ToDiagnosisDto(this IReadOnlyList<Diagnosis> diagnoses)
        {
            return diagnoses.Select(d => d.ToDiagnosisDto()).ToList();
        }

        public static DiagnosisDto ToDiagnosisDto(this Diagnosis diagnosis)
        {
            return new DiagnosisDto(
                Id: diagnosis.Id,
                Code: diagnosis.Code,
                Name: diagnosis.Name,
                ShortDescription: diagnosis.ShortDescription,
                LongDescription: diagnosis.LongDescription
            );
        }
    }
}