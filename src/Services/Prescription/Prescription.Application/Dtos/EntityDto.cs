using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Dtos
{
    public abstract record EntityDto(
        Guid Id, DateTime? CreatedAt,
        string? CreatedBy,
        DateTime? LastModified,
        string? LastModifiedBy
        );
}