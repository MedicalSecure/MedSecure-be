﻿
namespace BacPatient.Infrastructure.Data.Configurations
{
    internal class PosologyConfiguration : IEntityTypeConfiguration<Posology>
    {
        public void Configure(EntityTypeBuilder<Posology> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Dispenses)
                        .WithOne(dispense => dispense.posology)
                    .HasForeignKey(dispense => dispense.PosologyId);

            builder.HasMany(p => p.Comments)
                        .WithOne(comment => comment.posology)
                    .HasForeignKey(comment => comment.PosologyId);

            builder.HasOne(p => p.Medication)
            .WithMany()
            .HasForeignKey(p => p.MedicationId)
            .IsRequired();
        }
    }
}