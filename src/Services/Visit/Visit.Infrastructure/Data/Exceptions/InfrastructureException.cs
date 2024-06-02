using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Infrastructure.Data.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException(string message)
    : base($"Infrastructure Exception: \"{message}\" throws from Infrastructure Layer.")
    {
    }
}

