using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{
    public static class SymptomExtension
    {
        public static ICollection<SymptomDto> ToSymptomsDto(this IReadOnlyList<Symptom> symptoms)
        {
            return symptoms.Select(s => s.ToSymptomDto()).ToList();
        }

        public static SymptomDto ToSymptomDto(this Symptom symptom)
        {
            return new SymptomDto(
                Id: symptom.Id.Value,
                Code: symptom.Code,
                Name: symptom.Name,
                ShortDescription: symptom.ShortDescription,
                LongDescription: symptom.LongDescription
            );
        }
    }
}