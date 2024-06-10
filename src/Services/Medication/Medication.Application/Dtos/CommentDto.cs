using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Dtos
{
    public record CommentDto(Guid Id, Guid PosologyId, string Label, string Content, string CreatedBy, DateTime CreatedAt);
}