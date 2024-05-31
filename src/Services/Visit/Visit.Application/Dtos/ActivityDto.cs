using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Dtos;
    public record ActivityDto(
     Guid Id,
     string Content,
     Guid CreatedBy,
     string CreatorName,
     DateTime CreatedAt
 );
