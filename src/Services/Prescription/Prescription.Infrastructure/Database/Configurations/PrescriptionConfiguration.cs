using Prescription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Infrastructure.Database.Configurations
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

            /*            builder.HasOne(prescription => prescription.Patient)
                            .WithMany()
                            .HasForeignKey(prescription => prescription.PatientId).IsRequired(); ;

                        builder.HasOne(p => p.Doctor)
                            .WithMany()
                            .HasForeignKey(prescription => prescription.DoctorId).IsRequired(); ;*/
            builder.HasOne(prescription => prescription.Patient)
        .WithMany(patient => patient.Prescriptions)
        .HasForeignKey(prescription => prescription.PatientId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            builder.HasOne(prescription => prescription.Doctor)
                .WithMany(doctor => doctor.Prescriptions)
                .HasForeignKey(prescription => prescription.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            // Ignore the circular reference
            builder.Navigation(p => p.Patient).AutoInclude(false);
            builder.Navigation(p => p.Doctor).AutoInclude(false);
        }
    }
}