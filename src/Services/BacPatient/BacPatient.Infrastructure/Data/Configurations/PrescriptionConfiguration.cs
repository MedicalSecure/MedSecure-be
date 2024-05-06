﻿

namespace BacPatient.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public PrescriptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(Prescription => Prescription.Symptoms)
                .WithMany(Sym => Sym.Prescriptions);

            builder.HasMany(Prescription => Prescription.Diagnosis)
                .WithMany(diag => diag.Prescriptions);

            builder.HasMany(Prescription => Prescription.Posology)
                .WithOne(Posology => Posology.Prescription);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}