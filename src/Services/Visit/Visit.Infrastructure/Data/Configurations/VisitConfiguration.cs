

namespace Visit.Infrastructure.Data.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Domain.Models.Visit>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Visit> builder)
        {
            // Primary key definition
            builder.HasKey(i => i.Id);

            // Configuration for the Id property
            builder.Property(i => i.Id)
                .HasConversion(visitId => visitId.Value,
                               dbId => VisitId.Of(dbId));


            // Configuration for the relationship between Visit and Patient
            builder.OwnsOne(b => b.Patient, patient =>
            {
                patient.Property(mi => mi.Id)
                .HasConversion(id => id.Value,
                               dbId => PatientId.Of(dbId));

                patient.Property(wi => wi.FirstName).HasMaxLength(50)
                      .IsRequired();

                patient.Property(wi => wi.LastName).HasMaxLength(50)
                    .IsRequired();

                patient.Property(wi => wi.DateOfBirth)
                    .IsRequired();

                patient.Property(mi => mi.Gender).HasDefaultValue(Gender.Other).
                    HasConversion(
                    mi => mi.ToString(),
                    gender => (Gender)Enum.Parse(typeof(Gender), gender));

            });
            // Configuration for the DoctorId property
            builder.Property(i => i.DoctorId)
                .IsRequired() // Assuming DoctorId is required
                .HasConversion(doctorId => doctorId.Value,
                               dbId => DoctorId.Of(dbId));

          

            // Configuration for other properties
            builder.Property(i => i.StartDate).IsRequired();
            builder.Property(i => i.EndDate).IsRequired();
            builder.Property(i => i.Title).IsRequired();
            builder.Property(i => i.TypeVisit).IsRequired();
            builder.Property(i => i.LocationVisit).IsRequired();
            builder.Property(i => i.Duration).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Availability).IsRequired();
        }
    }
}
