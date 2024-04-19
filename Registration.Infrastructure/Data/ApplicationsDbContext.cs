using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Domain.Models;
using System.Reflection;

namespace Registration.Infrastructure.Data
{
    public class ApplicationsDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options) { }

        

        public DbSet<RiskFactor> RiskFactors => Set<RiskFactor>();

        public DbSet<Register> Registers => Set<Register>();

        public DbSet<Patient> Patients => Set<Patient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
