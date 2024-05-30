using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.ValueObjects
{
    public record Dose(int Quantity, bool isValid = false, bool isPostValid = false);
}