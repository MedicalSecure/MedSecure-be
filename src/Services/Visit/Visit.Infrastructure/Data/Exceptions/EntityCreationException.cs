using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Infrastructure.Data.Exceptions;
public class EntityCreationException : InfrastructureException
{
    public EntityCreationException(string entityType, string message)
        : base($"Error creating {entityType}:\"{message}\"") { }
}
