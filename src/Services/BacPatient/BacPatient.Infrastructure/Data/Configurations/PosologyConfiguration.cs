
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class PosologyConfiguration : IEntityTypeConfiguration<Posology>
{
    public void Configure(EntityTypeBuilder<Posology> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => PoslogyId.Of(dbId));
       
    }
}