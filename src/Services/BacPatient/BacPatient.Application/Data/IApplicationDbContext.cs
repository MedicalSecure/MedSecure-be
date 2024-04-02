


using Microsoft.EntityFrameworkCore;

namespace BacPatient.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.BPModel> BacPatients { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
