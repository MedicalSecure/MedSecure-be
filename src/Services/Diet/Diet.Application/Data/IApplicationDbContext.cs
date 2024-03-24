

namespace Diet.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Diet> Diets { get; }

    DbSet<Meal> Meals { get; }

    DbSet<Food> Foods { get; }

    DbSet<Patient> Patients { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
