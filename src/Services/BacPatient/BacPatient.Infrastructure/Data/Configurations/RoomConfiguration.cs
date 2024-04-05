
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => RoomId.Of(dbId));
       
    }
}