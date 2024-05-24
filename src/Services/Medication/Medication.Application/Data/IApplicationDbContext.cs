namespace Medication.Application.Data;


public interface IApplicationDbContext
{
    DbSet<Drug> Drugs { get; }
    DbSet<Dosage> Dosages { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
