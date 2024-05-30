using BacPatient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Database.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(medication => medication.Id);
            builder.Property(p => p.Id)
                  .HasConversion(medicationId => medicationId.Value,
                                 dbId => MedicationId.Of(dbId));

            builder.Property(m => m.Name)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(m => m.Price)
            .HasColumnType("decimal(18,4)");

            builder.Property(m => m.Dosage)
                .HasMaxLength(50);

            builder.Property(m => m.Form)
                .HasMaxLength(50);

            builder.Property(m => m.Code)
                .HasMaxLength(50);

            builder.Property(m => m.Unit)
                .HasMaxLength(20);

            builder.Property(m => m.Description);

            builder.Property(m => m.ExpiredAt);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}