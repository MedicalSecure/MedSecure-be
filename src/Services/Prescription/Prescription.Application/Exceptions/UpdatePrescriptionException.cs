using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Exceptions
{
    public class UpdatePrescriptionException : Exception
    {
        public UpdatePrescriptionException()
        {
        }

        public UpdatePrescriptionException(string message)
            : base(message)
        {
        }

        public UpdatePrescriptionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}