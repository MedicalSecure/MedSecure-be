namespace Prescription.Infrastructure.Database.Configurations
{
    internal class ValidationConfiguration : IEntityTypeConfiguration<Validation>
    {
        public void Configure(EntityTypeBuilder<Validation> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
        .HasConversion(ValidationId => ValidationId.Value,
                   dbId => ValidationId.Of(dbId));

            builder.Property(p => p.PrescriptionId)
        .HasConversion(prescriptionId => prescriptionId.Value,
                   dbId => PrescriptionId.Of(dbId));

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}