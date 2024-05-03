

namespace BacPatient.Infrastructure.Data.Configurations;

public class UnitCareConfiguration : IEntityTypeConfiguration<Domain.Models.UnitCare>
{
    public void Configure(EntityTypeBuilder<Domain.Models.UnitCare> builder)
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
    }
}