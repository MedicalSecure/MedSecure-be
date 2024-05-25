using FluentValidation;
using Prescription.Application.Features.Symptom.Commands.UpdateSymptom;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public record PredictFromSymptomsQuery(List<SymptomDTO> Symptoms) : IQuery<PredictFromSymptomsResult>;
    public record PredictFromSymptomsResult(DiagnosisDTO? PredictedDiagnosis);

    public class PredictFromSymptomsResultQueryValidator : AbstractValidator<PredictFromSymptomsQuery>
    {
        public PredictFromSymptomsResultQueryValidator()
        {
        }
    }
}