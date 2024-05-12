namespace Medication.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Drug> Drugs => Set<Drug>();
    public DbSet<Dosage> Dosages => Set<Dosage>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        /*        modelBuilder.Entity<Medication>()
                    .HasIndex(m => new { m.Name, m.Dosage, m.Form, m.Code, m.Unit, m.Description })
                    .HasDatabaseName("IX_Medication");*/
    }
}