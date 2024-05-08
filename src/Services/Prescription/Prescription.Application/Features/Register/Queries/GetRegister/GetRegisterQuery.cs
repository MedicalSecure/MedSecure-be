using FluentValidation;
using Prescription.Application.Features.Diagnosis.Commands.UpdateDiagnosis;

namespace Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis
{
    public record GetRegisterQuery(PaginationRequest PaginationRequest) : IQuery<GetRegisterResult>;
    public record GetRegisterResult(PaginatedResult<RegisterDto> Registrations);

    public class GetRegisterQueryValidator : AbstractValidator<GetRegisterQuery>
    {
        public GetRegisterQueryValidator()
        {
            /*            RuleFor(x => x.PaginationRequest.PageIndex).NotEmpty().WithMessage("Page Index is required")
                            .GreaterThan(-1).WithMessage("Page Index must be positive");
                        RuleFor(x => x.PaginationRequest.PageSize).NotEmpty().WithMessage("Page Size is required")
                            .GreaterThan(-1).WithMessage("Page Size must be positive");*/
        }
    }
}