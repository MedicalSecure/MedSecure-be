using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Extensions
{
    public static partial class TaskExtension {
        public static IEnumerable<TaskDto> ToTaskDto(this IEnumerable<Domain.Models.Task> tasks)
        {
            return tasks.Select(t => new TaskDto(
                            Id: t.Id.Value,
                            Content: t.Content,
                            TaskState: t.TaskState,
                            TaskAction: t.TaskAction

                   )).ToList();
        }
    }
  
}

