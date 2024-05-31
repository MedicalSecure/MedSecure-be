using FluentValidation;
using Prescription.Application.Features.Symptom.Commands.UpdateSymptom;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public record GetSymptomQuery(PaginationRequest PaginationRequest) : IQuery<GetSymptomResult>;
    public record GetSymptomResult(PaginatedResult<SymptomDTO> Symptom);

    public class GetSymptomQueryValidator : AbstractValidator<GetSymptomQuery>
    {
        public GetSymptomQueryValidator()
        {
            RuleFor(x => x.PaginationRequest.PageIndex).NotEmpty().WithMessage("Page Index is required")
                .GreaterThan(-1).WithMessage("Page Index must be positive");
            RuleFor(x => x.PaginationRequest.PageSize).NotEmpty().WithMessage("Page Size is required")
                .GreaterThan(-1).WithMessage("Page Size must be positive");
        }
    }
}