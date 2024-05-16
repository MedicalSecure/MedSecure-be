using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record ActivityDto(
    Guid Id,
    string Content,
    Guid CreatedBy,
    string CreatorName,
    DateTime CreatedAt
);
}