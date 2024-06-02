using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Dtos.BacPatientSimpleDto
{
    public record SimpleRegisterDto
    {
        public Guid Id { get; init; }
        public SimplePatientDto Patient { get; init; }

    }
}
