using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.DTOs
{
    public record SymptomDto(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
}