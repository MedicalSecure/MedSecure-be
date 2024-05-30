namespace Prescription.Infrastructure.Database.Configurations
{
    internal class PosologyConfiguration : IEntityTypeConfiguration<Posology>
    {
        public void Configure(EntityTypeBuilder<Posology> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
        .HasConversion(PosologyId => PosologyId.Value,
                   dbId => PosologyId.Of(dbId));

            builder.Property(p => p.PrescriptionId)
        .HasConversion(prescriptionId => prescriptionId.Value,
                   dbId => PrescriptionId.Of(dbId));

            builder.HasMany(p => p.Dispenses)
                        .WithOne(dispense => dispense.Posology)
                    .HasForeignKey(dispense => dispense.PosologyId);

            builder.HasMany(p => p.Comments)
                        .WithOne(comment => comment.posology)
                    .HasForeignKey(comment => comment.PosologyId);

            builder.HasOne(p => p.Medication)
                    .WithMany()
                    .HasForeignKey(p => p.MedicationId)
                    .IsRequired();

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}