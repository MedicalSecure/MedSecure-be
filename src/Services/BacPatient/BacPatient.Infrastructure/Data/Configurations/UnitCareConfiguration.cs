
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class UnitCareConfiguration : IEntityTypeConfiguration<UnitCare>
{
    public void Configure(EntityTypeBuilder<UnitCare> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => UnitCareId.Of(dbId));
       
    }
}