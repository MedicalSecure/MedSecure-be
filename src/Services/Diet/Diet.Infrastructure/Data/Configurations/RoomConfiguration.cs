

namespace Diet.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r=> r.Id)
               .HasConversion(roomId => roomId.Value,
                              dbId => RoomId.Of(dbId));



        builder.Property(wi => wi.RoomNumber) 
              .IsRequired()
              .HasColumnType("decimal(10, 2)");
        builder.HasOne<UnitCare>()
                  .WithOne(d => d.Room).HasForeignKey<Room>(e => e.UnitCareId)
                  .IsRequired();
        builder.Property(r => r.Status)
            .HasConversion(
            dt => dt.ToString(),
            Status => (Status)Enum.Parse(typeof(Status), Status));
    }
}

