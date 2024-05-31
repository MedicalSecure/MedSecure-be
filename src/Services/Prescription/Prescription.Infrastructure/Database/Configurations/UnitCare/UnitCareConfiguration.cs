namespace Prescription.Infrastructure.Database.Configurations
{
    public class UnitCareConfiguration : IEntityTypeConfiguration<UnitCare>
    {
        public void Configure(EntityTypeBuilder<UnitCare> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasConversion(unitCareId => unitCareId.Value,
                                  dbId => UnitCareId.Of(dbId));

            builder.Property(u => u.Type)
                          .IsRequired();

            builder.Property(u => u.Title)
                   .IsRequired();

            builder.Property(u => u.Description)
                  .IsRequired();

            builder.HasMany(u => u.Rooms)
                .WithOne()
                .HasForeignKey(t => t.UnitCareId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Personnels)
              .WithOne()
              .HasForeignKey(t => t.UnitCareId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}