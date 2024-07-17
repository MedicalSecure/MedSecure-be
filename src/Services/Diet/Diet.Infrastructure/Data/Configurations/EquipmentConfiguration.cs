namespace Diet.Infrastructure.Data.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasConversion(equipmentId => equipmentId.Value,
                                  dbId => EquipmentId.Of(dbId));

        builder.Property(wi => wi.Name).HasMaxLength(255);

        builder.Property(wi => wi.Reference).HasMaxLength(500);
        builder.HasOne<Room>()
                   .WithOne(d => d.Equipment).HasForeignKey<Equipment>(e => e.RoomId)
                   .IsRequired();


    }
    }


