using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Activity.Queries.GetActivities
{
    public record GetActivitiesQuery(PaginationRequest PaginationRequest) : IQuery<GetActivitiesResult>;
    public record GetActivitiesResult(PaginatedResult<ActivityDto> Activities);

    public class GetActivitiesQueryValidator : AbstractValidator<GetActivitiesQuery>
    {
        public GetActivitiesQueryValidator()
        {
            /*            RuleFor(x => x.PaginationRequest.PageIndex).NotEmpty().WithMessage("Page Index is required")
                            .GreaterThan(-1).WithMessage("Page Index must be positive");
                        RuleFor(x => x.PaginationRequest.PageSize).NotEmpty().WithMessage("Page Size is required")
                            .GreaterThan(-1).WithMessage("Page Size must be positive");*/
        }
    }
}
