
using BacPatient.Domain.Enums;

namespace BacPatient.Infrastructure.Data.Configurations;

public class BacPatientConfiguration : IEntityTypeConfiguration<Domain.Models.BacPatient>
{
    public void Configure(EntityTypeBuilder<Domain.Models.BacPatient> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => BacPatienId.Of(dbId));
        builder.Property(b => b.PatientId)
            .IsRequired(false)
               .HasConversion(patientid => patientid.Value,
                              patientId => PatientId.Of(patientId));
        builder.Property(b => b.RoomId)
            .IsRequired(false)
              .HasConversion(roomid => roomid.Value,
                             roomId => RoomId.Of(roomId));
        builder.Property(b => b.UnitCareId).IsRequired(false)
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
        builder.Property(d => d.Status).
            HasConversion(
            dt => dt.ToString(),
            status => (StatusBP)Enum.Parse(typeof(StatusBP), status));

        builder.Property(wi => wi.Bed)
               .IsRequired();

        builder.Property(wi => wi.ServingDate)
              .IsRequired();

        builder.Property(wi => wi.Served)
              .IsRequired();

        builder.Property(wi => wi.ToServe)
              .IsRequired();
    }
}