
namespace BacPatient.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Domain.Models.BacPatient> BacPatients => Set<BacPatient.Domain.Models.BacPatient>();

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<UnitCare> UnitCares => Set<UnitCare>();

    public DbSet<PrescriptionEntity> Prescriptions => Set<PrescriptionEntity>();

    public DbSet<Symptom> Symptoms => Set<Symptom>();

    public DbSet<Diagnosis> Diagnosis => Set<Diagnosis>();

    public DbSet<Dispense> Dispenses => Set<Dispense>();

    public DbSet<Posology> Posology => Set<Posology>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Medication> Medications => Set<Medication>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
