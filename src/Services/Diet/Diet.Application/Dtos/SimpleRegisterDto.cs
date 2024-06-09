using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Dtos
{
   
    public record SimpleRegisterDto(
               Guid Id,
               SimplePatientDto Patient,
               List<SimpleRiskFactorDto> Allergies ,
               List<SimpleRiskFactorDto> Diseases);
    public record SimpleRiskFactorDto(
              Guid Id ,
           string? Value ,
           string? Type );
}

