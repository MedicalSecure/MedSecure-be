using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Extensions
{
    public static partial class ActivityExtension
    {
        public static IEnumerable<ActivityDto> ToActivityDto(this IEnumerable<Domain.Models.Activity> activities)
        {
            return activities.Select(a => new ActivityDto(
                            Id: a.Id,
                            Content: a.Content,
                            CreatedAt: a.CreatedAt,
                            CreatedBy: a.CreatedBy,
                            CreatorName: a.CreatorName
                                  )).ToList();
                               
        }

    }

}
