using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Domain.ValueObjects;

public record Dose(int Quantity, bool isValid = false, bool isPostValid = false);