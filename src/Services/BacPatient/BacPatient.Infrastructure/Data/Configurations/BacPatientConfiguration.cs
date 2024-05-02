

namespace BacPatient.Infrastructure.Data.Configurations;

public class BacPatientConfiguration : IEntityTypeConfiguration<Domain.Models.BacPatient>
{
    public void Configure(EntityTypeBuilder<Domain.Models.BacPatient> builder)
    {
        builder.HasKey(b => b.Id);
       
        builder.Property(b => b.Id)
               .HasConversion(bpModelid => bpModelid,
                              dbId => dbId);
    
    
        builder.HasOne(bacPatient => bacPatient.Prescription)
              .WithMany(prescription => prescription.bacPatients)
              .HasForeignKey(BacPatient => BacPatient.Id)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        builder.Property(d => d.Status).
            HasConversion(
            dt => dt.ToString(),
            status => (StatusBP)Enum.Parse(typeof(StatusBP), status));

        builder.Property(wi => wi.Bed)
               .IsRequired();

       

        builder.Property(wi => wi.Served)
              .IsRequired();

        builder.Property(wi => wi.ToServe)
              .IsRequired();
    }
}