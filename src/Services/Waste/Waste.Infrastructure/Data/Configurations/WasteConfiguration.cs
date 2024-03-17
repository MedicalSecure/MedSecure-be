
namespace Waste.Infrastructure.Data.Configurations;

public class WasteConfiguration : IEntityTypeConfiguration<Domain.Models.Waste>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Waste> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
               .HasConversion(wasteId => wasteId.Value,
                              dbId => WasteId.Of(dbId));

        builder.HasOne<Room>()
               .WithMany()
               .HasForeignKey(w => w.RoomId);

        builder.HasMany(w => w.WasteItems)
               .WithOne()
               .HasForeignKey(wi => wi.WasteId);

        builder.ComplexProperty(w => w.PickupLocation, pickupLocation =>
        {
            pickupLocation.Property(p => p.Street).HasMaxLength(50);
            pickupLocation.Property(p => p.City).HasMaxLength(50);
            pickupLocation.Property(p => p.State).HasMaxLength(50);
            pickupLocation.Property(p => p.ZipCode).HasMaxLength(5);
            pickupLocation.Property(p => p.Country).HasMaxLength(50);
            pickupLocation.Property(p => p.Phone).HasMaxLength(50);
            pickupLocation.Property(p => p.Email).HasMaxLength(50);
        });

        builder.ComplexProperty(w => w.DropOffLocation, dropOffLocation =>
        {
            dropOffLocation.Property(p => p.Street).HasMaxLength(50);
            dropOffLocation.Property(p => p.City).HasMaxLength(50);
            dropOffLocation.Property(p => p.State).HasMaxLength(50);
            dropOffLocation.Property(p => p.ZipCode).HasMaxLength(5);
            dropOffLocation.Property(p => p.Country).HasMaxLength(50);
            dropOffLocation.Property(p => p.Phone).HasMaxLength(50);
            dropOffLocation.Property(p => p.Email).HasMaxLength(50);
        });

        builder.Property(w => w.Status).HasDefaultValue(WasteStatus.Pending).
            HasConversion(
            ws => ws.ToString(),
            dbStatus => (WasteStatus)Enum.Parse(typeof(WasteStatus), dbStatus));

        builder.Property(w => w.Color).HasDefaultValue(WasteColor.Black).
            HasConversion(
            wc => wc.ToString(),
            dbColor => (WasteColor)Enum.Parse(typeof(WasteColor), dbColor));
    }
}

