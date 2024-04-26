
using Microsoft.EntityFrameworkCore;
using Registration.Domain.Models;

namespace Registration.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Patient> Patients { get; }
        DbSet<Domain.Models.Register> Registers { get; }
        DbSet<RiskFactor> RiskFactors { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
