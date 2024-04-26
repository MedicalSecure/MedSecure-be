using FluentValidation;
using Prescription.Application.Features.Symptom.Commands.UpdateSymptom;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public record PredictFromSymptomsQuery(List<SymptomDto> Symptoms) : IQuery<PredictFromSymptomsResult>;
    public record PredictFromSymptomsResult(DiagnosisDto PredictedDiagnosis);

    public class PredictFromSymptomsResultQueryValidator : AbstractValidator<PredictFromSymptomsQuery>
    {
        public PredictFromSymptomsResultQueryValidator()
        {
        }
    }
}