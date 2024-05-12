namespace Medication.Infrastructure.Database.Configurations;

public class DosageConfiguration : IEntityTypeConfiguration<Dosage>
{
    public void Configure(EntityTypeBuilder<Dosage> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasConversion(
            dosageId => dosageId.Value,
            dbId => DosageId.Of(dbId));

        builder.Property(d => d.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.Label)
            .HasMaxLength(50)
            .IsRequired();
    }
}
