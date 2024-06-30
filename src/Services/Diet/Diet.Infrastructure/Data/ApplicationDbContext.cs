
namespace Diet.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Domain.Models.Diet> Diets => Set<Domain.Models.Diet>();

    public DbSet<Meal> Meals => Set<Meal>();

    public DbSet<Food> Foods => Set<Food>();
    public DbSet<RiskFactor> RiskFactors => Set<RiskFactor>();

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<UnitCare> UnitCares => Set<UnitCare>();

    public DbSet<Prescription> Prescriptions => Set<Prescription>();

    public DbSet<Symptom> Symptoms => Set<Symptom>();

    public DbSet<Diagnosis> Diagnosis => Set<Diagnosis>();

    public DbSet<Dispense> Dispenses => Set<Dispense>();

    public DbSet<Posology> Posology => Set<Posology>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Register> Registers => Set<Register>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<Domain.Models.Activity> Activities { get; set; }

    public DbSet<Equipment> Equipments => Set<Equipment>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
