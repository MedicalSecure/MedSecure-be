using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rescription.Application.DTOs
{
    public record MedicationDto(Guid Id,
        string? Name,
        string? Dosage,
        Route? Form,
        string? Code,
        string? Unit,
        string? Description,
        DateTime? ExpiredAt,
        int? Stock,
        int? AlertStock,
        int? AvrgStock,
        int? MinStock,
        int? SafetyStock,
        int? ReservedStock,
        decimal? Price);
}