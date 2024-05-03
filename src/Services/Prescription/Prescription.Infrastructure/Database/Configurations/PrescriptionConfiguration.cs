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
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Domain.Entities.PrescriptionRoot.Prescription>
    {
        public PrescriptionConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Domain.Entities.PrescriptionRoot.Prescription> builder)
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
            // Ignore the circular reference
            //builder.Navigation(p => p.Register).AutoInclude(false);
            //builder.Navigation(p => p.Doctor).AutoInclude(false);
        }
    }
}