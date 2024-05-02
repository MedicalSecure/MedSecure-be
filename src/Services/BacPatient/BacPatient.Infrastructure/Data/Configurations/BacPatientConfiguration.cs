

namespace BacPatient.Infrastructure.Data.Configurations;

public class BacPatientConfiguration : IEntityTypeConfiguration<Domain.Models.BacPatient>
{
    public void Configure(EntityTypeBuilder<Domain.Models.BacPatient> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid.Value,
                              dbId => BacPatienId.Of(dbId));
        builder.OwnsOne(b => b.Patient, patient =>
        {
            patient.Property(p => p.Id).IsRequired();
            patient.Property(p => p.PatientName).IsRequired();
            patient.Property(p => p.DateOfBirth).IsRequired();

        });
        builder.OwnsOne(b => b.Room, patient =>
        {
            patient.Property(p => p.Id).IsRequired()
            .HasConversion(bpModelid => bpModelid.Value,
                              dbId => RoomId.Of(dbId));
            patient.Property(p => p.Number).IsRequired();



        });
        builder.OwnsOne(b => b.UnitCare, patient =>
        {
            patient.Property(p => p.Id).IsRequired()
            .HasConversion(bpModelid => bpModelid.Value,
                              dbId => UnitCareId.Of(dbId));
            patient.Property(p => p.Title).IsRequired();

        });
      
 
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