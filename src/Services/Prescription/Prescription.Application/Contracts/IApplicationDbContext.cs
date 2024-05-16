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
        DbSet<Domain.Entities.Prescription> Prescriptions { get; }
        public DbSet<Symptom> Symptoms { get; }
        public DbSet<Diagnosis> Diagnosis { get; }
        public DbSet<Dispense> Dispenses { get; }
        public DbSet<Posology> Posology { get; }
        public DbSet<Comment> Comments { get; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Medication> Medications { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public void AttachEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}