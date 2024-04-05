
using Visit.Domain.Models;

namespace Visit.Application.Data;

public interface  IApplicationDbContext
{
    DbSet<Domain.Models.Visit>  Visits { get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
