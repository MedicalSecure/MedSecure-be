namespace UnitCare.Infrastructure.Data.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasConversion(equipmentId => equipmentId.Value,
                                  dbId => EquipmentId.Of(dbId));

            builder.HasOne<Room>()
                   .WithMany(d => d.Equipments)
                   .HasForeignKey(w => w.RoomId)
                  .OnDelete(DeleteBehavior.Cascade);

        builder.Property(wi => wi.Name).HasMaxLength(255)
                   .IsRequired();

            builder.Property(wi => wi.Reference).HasMaxLength(500)
                  .IsRequired();

        builder.Property(wi => wi.EqStatus).HasMaxLength(500)
            .IsRequired();


    }
    }


