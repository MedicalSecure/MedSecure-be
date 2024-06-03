using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Dtos
{
    public record SimpleRegisterDto
    {
        public Guid Id { get; init; }
        public SimplePatientDto Patient { get; init; }

    }
}
