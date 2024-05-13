using Prescription.Application.Contracts;
using Prescription.Domain.Entities;
using Prescription.Infrastructure.Database.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Proxies;

namespace Prescription.Infrastructure.Database
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Prescription> Prescriptions { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Dispense> Dispenses { get; set; }
        public DbSet<Posology> Posology { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RiskFactor> RiskFactor { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Register> Register { get; set; }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //This line calls the ApplyConfigurationsFromAssembly method on the modelBuilder.
            //It searches the currently executing assembly(using Assembly.GetExecutingAssembly()) for classes that implement the IEntityTypeConfiguration < TEntity > interface.
            //These classes likely contain specific configuration logic for individual entity types in your application
            //By calling this method, Entity Framework Core automatically applies the configuration defined in those classes to the model.

            base.OnModelCreating(modelBuilder);
            //The DbContext class itself might have some default model configuration logic implemented in its OnModelCreating method.
            //By calling base.OnModelCreating(modelBuilder), you ensure that any configuration defined in the base class is still applied to the model.This could include things like setting conventions for naming conventions, pluralization, or other behaviors.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        public void AttachEntity<TEntity>(TEntity entity) where TEntity : class
        {
            Attach(entity);
        }
    }
}