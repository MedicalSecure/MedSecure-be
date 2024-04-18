


using Microsoft.EntityFrameworkCore;

namespace BacPatient.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.BacPatient> BacPatients { get; }
    DbSet<Domain.Models.Patient> Patients { get; }
    DbSet<Domain.Models.Room> Rooms { get; }
    DbSet<Domain.Models.UnitCare> UnitCares { get; }
    DbSet<Domain.Models.Medicine> Medecines { get; }
    DbSet<Domain.Models.Posology> Posologies { get; }
 
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
