
namespace Registration.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Register> Registers => Set<Register>();
    public DbSet<RiskFactor> RiskFactors => Set<RiskFactor>();
    public DbSet<SubRiskFactor> SubRiskFactors => Set<SubRiskFactor>();
    public DbSet<History> Histories => Set<History>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Test> Tests => Set<Test>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        
    }
}
