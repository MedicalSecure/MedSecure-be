namespace Medication.Infrastructure.Database.Configurations;

internal class ValidationsConfiguration : IEntityTypeConfiguration<Validation>
{
    public void Configure(EntityTypeBuilder<Validation> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(validationId => validationId.Value,
               dbId => ValidationId.Of(dbId));

        //ENSURE THAT THE VALIDATION For a single prescription cant happen twice!!
        builder.HasIndex(p => p.PrescriptionId)
       .IsUnique();

        builder.HasMany(p => p.Posologies)
                    .WithOne(comment => comment.Validation)
                .HasForeignKey(comment => comment.ValidationId);

        builder.Property(d => d.LastModifiedBy)
            .HasMaxLength(128);

        builder.Property(d => d.PharmacistName)
            .HasMaxLength(128);

        builder.Property(d => d.CreatedBy)
            .HasMaxLength(128);
    }
}