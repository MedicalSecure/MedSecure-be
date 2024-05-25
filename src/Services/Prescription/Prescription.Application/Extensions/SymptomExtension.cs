using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Extensions
{
    public static class SymptomExtension
    {
        public static ICollection<SymptomDTO> ToSymptomsDto(this IReadOnlyList<Symptom> symptoms)
        {
            return symptoms.Select(s => s.ToSymptomDto()).ToList();
        }

        public static SymptomDTO ToSymptomDto(this Symptom symptom)
        {
            return new SymptomDTO(
                Id: symptom.Id.Value,
                Code: symptom.Code,
                Name: symptom.Name,
                ShortDescription: symptom.ShortDescription,
                LongDescription: symptom.LongDescription
            );
        }
    }
}