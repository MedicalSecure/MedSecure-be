using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Dtos
{
    public record TaskDto(Guid Id, string Content, TaskState TaskState, TaskAction TaskAction);
}
