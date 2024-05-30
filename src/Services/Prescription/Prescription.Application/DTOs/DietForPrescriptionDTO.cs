using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record DietForPrescriptionDTO(
    Guid? Id,
    DateTime StartDate,
    DateTime EndDate,
    List<Guid> DietsId
    );
}