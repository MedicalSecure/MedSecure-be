namespace Medication.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Drug> Drugs => Set<Drug>();
    public DbSet<Dosage> Dosages => Set<Dosage>();

    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<Posology> Posologies => Set<Posology>();
    public DbSet<Validation> Validations => Set<Validation>();
    public DbSet<Dispense> Dispenses => Set<Dispense>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}