using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Sensor> Sensors { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
   

}
