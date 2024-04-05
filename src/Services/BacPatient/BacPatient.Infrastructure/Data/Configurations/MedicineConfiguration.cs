
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => MedicineId.Of(dbId));
       
    }
}