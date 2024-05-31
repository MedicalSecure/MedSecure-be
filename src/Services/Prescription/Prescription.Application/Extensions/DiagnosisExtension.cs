using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Extensions
{
    public static class DiagnosisExtension
    {
        public static ICollection<DiagnosisDTO> ToDiagnosisDto(this IReadOnlyList<Diagnosis> diagnoses)
        {
            return diagnoses.Select(d => d.ToDiagnosisDto()).ToList();
        }

        public static DiagnosisDTO ToDiagnosisDto(this Diagnosis diagnosis)
        {
            return new DiagnosisDTO(
                Id: diagnosis.Id.Value,
                Code: diagnosis.Code,
                Name: diagnosis.Name,
                ShortDescription: diagnosis.ShortDescription,
                LongDescription: diagnosis.LongDescription
            );
        }
    }
}