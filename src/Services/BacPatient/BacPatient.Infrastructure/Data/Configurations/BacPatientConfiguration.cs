

namespace BacPatient.Infrastructure.Data.Configurations;

public class BacPatientConfiguration : IEntityTypeConfiguration<Domain.Models.BacPatient>
{
    public void Configure(EntityTypeBuilder<Domain.Models.BacPatient> builder)
    {
        builder.HasKey(b => b.Id);
       
        builder.Property(p => p.Id)
              .HasConversion(personnelId => personnelId.Value,
                             dbId => BacPatienId.Of(dbId));

        builder.Property(d => d.Status).
            HasConversion(
            dt => dt.ToString(),
            status => (StatusBP)Enum.Parse(typeof(StatusBP), status));

      
       

        builder.Property(wi => wi.Served)
              .IsRequired();

        builder.Property(wi => wi.ToServe)
              .IsRequired();
    }
}