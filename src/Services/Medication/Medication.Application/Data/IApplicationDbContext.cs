namespace Medication.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Drug> Drugs { get; }
    DbSet<Dosage> Dosages { get; }
    DbSet<Activity> Activities { get; }
    public DbSet<Validation> Validations { get; }
    public DbSet<Posology> Posologies { get; }
    public DbSet<Dispense> Dispenses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}