

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
                    .IsRequired(false);

                patient.Property(wi => wi.DateOfBirth)
                    .IsRequired(false);

                patient.Property(mi => mi.Gender).HasDefaultValue(Gender.Other).
                    HasConversion(
                    mi => mi.ToString(),
                    gender => (Gender)Enum.Parse(typeof(Gender), gender));

                patient.Property(wi => wi.CIN)
                    .IsRequired(false);

                patient.Property(wi => wi.CNAM)
                    .IsRequired(false);

                patient.Property(wi => wi.Assurance)
                    .HasMaxLength(100)
                    .IsRequired(false);

                patient.Property(wi => wi.Gender)
                    .IsRequired(false);

                patient.Property(wi => wi.Height)
                    .IsRequired(false);

                patient.Property(wi => wi.Weight)
                    .IsRequired(false);

                patient.Property(wi => wi.AddressIsRegisterations)
                    .IsRequired(false);

                patient.Property(wi =>  wi.SaveForNextTime)
                    .IsRequired(false);

                patient.Property(wi => wi.Email)
                    .HasMaxLength(100)
                    .IsRequired(false);

                patient.Property(wi => wi.Address1)
                    .HasMaxLength(200)
                    .IsRequired(false);

                patient.Property(wi => wi.Address2)
                    .HasMaxLength(200)
                    .IsRequired(false);

                patient.Property(wi => wi.ActivityStatus)
                    .IsRequired(false);

                patient.Property(wi => wi.Country)
                    .IsRequired(false);

                patient.Property(wi => wi.State)
                    .HasMaxLength(50)
                    .IsRequired(false);

                patient.Property(wi => wi.ZipCode)
                    .IsRequired(false);

                patient.Property(wi => wi.FamilyStatus)
                    .IsRequired(false);

                patient.Property(wi => wi.Children)
                    .IsRequired(false);

                patient.Property(wi => wi.LastModifiedBy)
                    .HasMaxLength(128);

                patient.Property(wi => wi.CreatedBy)
                    .HasMaxLength(128);

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
