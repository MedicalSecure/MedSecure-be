namespace Pharmalink.Application.Data

{
    public interface IApplicationDbContext
    {
        DbSet<Medication> Medications { get; }
        DbSet<Dosage> Dosages { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
