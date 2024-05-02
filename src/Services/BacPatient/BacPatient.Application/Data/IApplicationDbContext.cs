﻿


using Microsoft.EntityFrameworkCore;

namespace BacPatient.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.BacPatient> BacPatients { get; }
    DbSet<Domain.Models.Room> Rooms { get; }
    DbSet<Domain.Models.UnitCare> UnitCares { get; }
    DbSet<PrescriptionEntity> Prescriptions { get; }
    public DbSet<Symptom> Symptoms { get; }
    public DbSet<Diagnosis> Diagnosis { get; }
    public DbSet<Dispense> Dispenses { get; }
    public DbSet<Posology> Posology { get; }
    public DbSet<Comment> Comments { get; }
    public DbSet<Room> Patients { get; }
    public DbSet<Doctor> Doctors { get; }
    public DbSet<Medication> Medications { get; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
