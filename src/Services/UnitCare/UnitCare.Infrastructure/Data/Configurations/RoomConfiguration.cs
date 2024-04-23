using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r=> r.Id)
               .HasConversion(roomId => roomId.Value,
                              dbId => RoomId.Of(dbId));

        builder.HasOne<Domain.Models.UnitCare>()
               .WithMany(r => r.Rooms)
               .HasForeignKey(u => u.UnitCareId);

        builder.Property(wi => wi.RoomNumber) 
              .IsRequired();

        builder.Property(r => r.Status)
            .HasConversion(
            dt => dt.ToString(),
            Status => (Status)Enum.Parse(typeof(Status), Status));
    }
}

