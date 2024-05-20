using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Exceptions
{
    public class CreatePrescriptionException : Exception
    {
        public CreatePrescriptionException()
        {
        }

        public CreatePrescriptionException(string message)
            : base(message)
        {
        }

        public CreatePrescriptionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
