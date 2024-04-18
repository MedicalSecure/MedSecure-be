
namespace BacPatient.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Domain.Models.BacPatient> BacPatients => Set<BacPatient.Domain.Models.BacPatient>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<UnitCare> UnitCares => Set<UnitCare>();
    public DbSet<Medicine> Medecines => Set<Medicine>();
    public DbSet<Posology> Posologies => Set<Posology>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
