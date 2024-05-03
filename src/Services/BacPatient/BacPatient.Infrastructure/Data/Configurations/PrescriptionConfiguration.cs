using BacPatient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class PrescriptionConfiguration : IEntityTypeConfiguration<PrescriptionEntity>
    {
        public PrescriptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<PrescriptionEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(Prescription => Prescription.Symptoms)
                .WithMany(Sym => Sym.Prescriptions);

            builder.HasMany(Prescription => Prescription.Diagnosis)
                .WithMany(diag => diag.Prescriptions);

            builder.HasMany(Prescription => Prescription.Posology)
                .WithOne(Posology => Posology.Prescription);

            builder.HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(prescription => prescription.DoctorId).IsRequired();

            builder.HasOne(prescription => prescription.Doctor)
                .WithMany(doctor => doctor.Prescriptions)
                .HasForeignKey(prescription => prescription.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
            // Ignore the circular reference
            //builder.Navigation(p => p.Register).AutoInclude(false);
            //builder.Navigation(p => p.Doctor).AutoInclude(false);
        }
    }
}