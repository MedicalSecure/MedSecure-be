using Medication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Dtos
{
    public record ValidationDto(Guid Id, Guid PrescriptionId, Guid PharmacistId, string UnitCareJson, List<PosologyDto> Posologies, string? PharmacistName, ValidationStatus Status, string? Notes, DateTime CreatedAt);
}