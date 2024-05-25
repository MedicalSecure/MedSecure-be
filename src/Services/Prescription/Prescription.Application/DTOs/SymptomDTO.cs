using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record SymptomDTO(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
}