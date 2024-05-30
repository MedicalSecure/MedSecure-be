namespace Prescription.Infrastructure.Database.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasConversion(roomId => roomId.Value,
                                  dbId => RoomId.Of(dbId));

            builder.HasOne<UnitCare>()
                   .WithMany(r => r.Rooms)
                   .HasForeignKey(u => u.UnitCareId);

            builder.Property(wi => wi.RoomNumber)
                  .IsRequired()
                  .HasColumnType("decimal(10, 2)");

            builder.Property(r => r.Status)
                .HasConversion(
                dt => dt.ToString(),
                Status => (RoomStatus)Enum.Parse(typeof(RoomStatus), Status));
        }
    }
}