using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Validations.Queries
{
    public record GetValidationsQuery(PaginationRequest PaginationRequest, bool pendingOnly = false) : IQuery<GetValidationsResult>;
    public record GetValidationsResult(PaginatedResult<ValidationDto> Validations);

    public class GetValidationsQueryValidator : AbstractValidator<GetValidationsQuery>
    {
        public GetValidationsQueryValidator()
        {
            /*            RuleFor(x => x.PaginationRequest.PageIndex).NotEmpty().WithMessage("Page Index is required")
                            .GreaterThan(-1).WithMessage("Page Index must be positive");
                        RuleFor(x => x.PaginationRequest.PageSize).NotEmpty().WithMessage("Page Size is required")
                            .GreaterThan(-1).WithMessage("Page Size must be positive");*/
        }
    }
}