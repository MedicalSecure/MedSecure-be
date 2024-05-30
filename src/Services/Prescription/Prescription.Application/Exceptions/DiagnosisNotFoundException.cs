using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Exceptions
{
    public class DiagnosisNotFoundException : NotFoundException
    {
        public DiagnosisNotFoundException(Guid id) : base(nameof(Diagnosis), id)
        {
        }
    }
}