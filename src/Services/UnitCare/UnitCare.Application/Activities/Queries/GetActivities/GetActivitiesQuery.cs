using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Activity.Queries.GetActivities
{
    public record GetActivitiesQuery(PaginationRequest PaginationRequest) : IQuery<GetActivitiesResult>;
    public record GetActivitiesResult(PaginatedResult<ActivityDto> Activities);

    public class GetActivitiesQueryValidator : AbstractValidator<GetActivitiesQuery>
    {
        public GetActivitiesQueryValidator()
        {
          
        }
    }
}
