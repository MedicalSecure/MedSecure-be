
using Registration.Infrastructure.Data.Configurations;

namespace Registration.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<History> Histories => Set<History>();
        public DbSet<RiskFactor> RiskFactors => Set<RiskFactor>();

        public DbSet<Register> Registers => Set<Register>();

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Test> Tests => Set<Test>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new RegisterConfiguration());
            modelBuilder.ApplyConfiguration(new RiskFactorConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            
        }
    }
}
