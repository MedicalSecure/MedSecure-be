using FluentValidation;
using Prescription.Application.Features.Symptom.Commands.UpdateSymptom;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public record GetSymptomByIdQuery(Guid Id) : IQuery<GetSymptomResult>;

    public class GetSymptomByIdQueryValidator : AbstractValidator<GetSymptomByIdQuery>
    {
        public GetSymptomByIdQueryValidator()
        {
        }
    }
}