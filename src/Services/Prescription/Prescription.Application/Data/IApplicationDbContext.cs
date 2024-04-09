using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<PrescriptionEntity> Prescriptions { get; }
        public DbSet<Symptom> Symptoms { get; }
        public DbSet<Diagnosis> Diagnosis { get; }
        public DbSet<Dispense> Dispenses { get; }
        public DbSet<Posology> Posology { get; }
        public DbSet<Comment> Comments { get; }
        public DbSet<Patient> Patients { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}