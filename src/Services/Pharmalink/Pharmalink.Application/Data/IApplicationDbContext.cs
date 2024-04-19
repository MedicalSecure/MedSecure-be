namespace Pharmalink.Application.Data

{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Models.Medication> Medications { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
