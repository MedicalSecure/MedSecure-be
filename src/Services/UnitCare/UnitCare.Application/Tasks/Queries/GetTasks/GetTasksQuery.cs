using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Tasks.Queries.GetTasks
{


    public record GetTasksQuery(PaginationRequest PaginationRequest)
: IQuery<GetTasksResult>;

    public record GetTasksResult(PaginatedResult<TaskDto> Tasks);
}
