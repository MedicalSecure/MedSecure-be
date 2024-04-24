

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

            // Configuration for the DoctorId property
            builder.Property(i => i.DoctorId)
                .IsRequired() // Assuming DoctorId is required
                .HasConversion(doctorId => doctorId.Value,
                               dbId => DoctorId.Of(dbId));

            // Configuration for the relationship between Visit and Patient
            builder.HasOne<Patient>()
                   .WithMany()
                   .HasForeignKey(w => w.PatientId);

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
