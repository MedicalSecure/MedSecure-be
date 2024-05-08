using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.PrescriptionRoot.Prescription> Prescriptions { get; }
        public DbSet<Symptom> Symptoms { get; }
        public DbSet<Diagnosis> Diagnosis { get; }
        public DbSet<Dispense> Dispenses { get; }
        public DbSet<Posology> Posology { get; }
        public DbSet<Comment> Comments { get; }
        public DbSet<RiskFactor> RiskFactor { get; set; }

        public DbSet<Patient> Patients { get; }
        public DbSet<Register> Register { get; }

        public DbSet<Medication> Medications { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}