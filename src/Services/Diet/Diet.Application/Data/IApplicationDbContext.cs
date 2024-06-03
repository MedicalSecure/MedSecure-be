

namespace Diet.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Diet> Diets { get; }

    DbSet<Meal> Meals { get; }

    DbSet<Food> Foods { get; }

    DbSet<Domain.Models.Room> Rooms { get; }
    DbSet<Domain.Models.UnitCare> UnitCares { get; }
    DbSet<Prescription> Prescriptions { get; }
    public DbSet<Symptom> Symptoms { get; }
    public DbSet<Domain.Models.Activity> Activities { get; }
    public DbSet<Diagnosis> Diagnosis { get; }
    public DbSet<Dispense> Dispenses { get; }
    public DbSet<Posology> Posology { get; }
    public DbSet<Comment> Comments { get; }
    public DbSet<Patient> Patients { get; }
    public DbSet<Medication> Medications { get; }

    public DbSet<Register> Registers { get; }
    public DbSet<Equipment> Equipments { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
