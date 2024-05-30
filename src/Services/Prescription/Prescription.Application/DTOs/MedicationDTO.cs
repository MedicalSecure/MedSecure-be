using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record MedicationDTO(Guid Id,
        string Name,
        string Dosage,
        string Form,
        string Code,
        string Unit,
        string Description,
        DateTime ExpiredAt,
        int Stock,
        int AlertStock,
        int AvrgStock,
        int MinStock,
        int SafetyStock,
        int ReservedStock,
        decimal Price);
}