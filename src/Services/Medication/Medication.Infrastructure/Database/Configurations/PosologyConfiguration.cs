namespace Medication.Infrastructure.Database.Configurations;

internal class PosologySummaryConfiguration : IEntityTypeConfiguration<Posology>
{
    public void Configure(EntityTypeBuilder<Posology> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
    .HasConversion(PosologySummaryId => PosologySummaryId.Value,
               dbId => PosologyId.Of(dbId));

        builder.HasMany(p => p.Comments)
                    .WithOne(comment => comment.Posology)
                .HasForeignKey(comment => comment.PosologyId);

        builder.HasMany(p => p.Dispenses)
                    .WithOne(comment => comment.Posology)
                .HasForeignKey(comment => comment.PosologyId);

        builder.HasOne(p => p.Drug)
                .WithMany()
                .HasForeignKey(p => p.DrugId)
                .IsRequired();

        builder.Property(d => d.LastModifiedBy)
            .HasMaxLength(128);

        builder.Property(d => d.CreatedBy)
            .HasMaxLength(128);
    }
}