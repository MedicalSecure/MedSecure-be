
using BacPatient.Domain.Enums;

namespace Diet.Infrastructure.Data.Configurations;

public class BPModelConfiguration : IEntityTypeConfiguration<BPModel>
{
    public void Configure(EntityTypeBuilder<BPModel> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => BPModelId.Of(dbId));

        builder.HasOne<Patient>()
              .WithMany()
              .HasForeignKey(w => w.PatientId);
        builder.HasOne<UnitCare>()
             .WithMany()
             .HasForeignKey(w => w.UnitCareId);
        builder.HasOne<Room>()
             .WithMany()
             .HasForeignKey(w => w.RoomId);
        builder.Property(d => d.status).
            HasConversion(
            dt => dt.ToString(),
            dietType => (StatusBP)Enum.Parse(typeof(StatusBP), dietType));

        builder.Property(wi => wi.bed)
               .IsRequired();

        builder.Property(wi => wi.servingDate)
              .IsRequired();

        builder.Property(wi => wi.served)
              .IsRequired();

        builder.Property(wi => wi.toServe)
              .IsRequired();
    }
}