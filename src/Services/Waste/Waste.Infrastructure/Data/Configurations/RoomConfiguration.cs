
namespace Waste.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(p => p.Id).HasConversion(roomId => roomId.Value,
            dbId => RoomId.Of(dbId));

        builder.Property(r => r.Name) 
               .HasMaxLength(255) 
               .IsRequired(); 

        builder.Property(r => r.Description)
               .HasMaxLength(1000); 
    }
}