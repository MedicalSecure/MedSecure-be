using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Data.Exceptions;

public class EntityCreationException :InfrastructureException
{
    public EntityCreationException(String entityType,String message):
        base ($"Error creating {entityType}: \"{message}\"")
    { }
}
