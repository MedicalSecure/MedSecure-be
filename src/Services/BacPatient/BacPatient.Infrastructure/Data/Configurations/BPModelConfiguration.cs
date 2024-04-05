
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class BPModelConfiguration : IEntityTypeConfiguration<BPModel>
{
    public void Configure(EntityTypeBuilder<BPModel> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => BPModelId.Of(dbId));
        builder.Property(b => b.PatientId)
               .HasConversion(patientid => patientid.Value,
                              patientId => PatientId.Of(patientId));
        builder.Property(b => b.RoomId)
              .HasConversion(roomid => roomid.Value,
                             roomId => RoomId.Of(roomId)); builder.Property(b => b.PatientId);
        builder.Property(b => b.UnitCareId)
             .HasConversion(unitid => unitid.Value,
                            unitId => UnitCareId.Of(unitId)); builder.Property(b => b.PatientId);

        builder.HasOne<Patient>()
              .WithMany()
              .HasForeignKey(w =>  w.PatientId);

        builder.HasOne<UnitCare>()
             .WithMany()
             .HasForeignKey(w => w.UnitCareId);
        builder.HasOne<Room>()
             .WithMany()
             .HasForeignKey(w => w.RoomId);
        builder.Property(d => d.status).
            HasConversion(
            dt => dt.ToString(),
            status => (StatusBP)Enum.Parse(typeof(StatusBP), status));

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