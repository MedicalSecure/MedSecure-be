using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System.Text.Json;

namespace Prescription.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                  .HasConversion(PatientId => PatientId.Value,
                             dbId => PatientId.Of(dbId));

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.DateOfBirth)
                .IsRequired(false);

            builder.Property(p => p.CIN)
                .IsRequired(false);

            builder.Property(p => p.CNAM)
                .IsRequired(false);

            builder.Property(p => p.Assurance)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Gender)
                .IsRequired(false);

            builder.Property(p => p.Height)
                .IsRequired(false);

            builder.Property(p => p.Weight)
                .IsRequired(false);

            builder.Property(p => p.AddressIsRegisterations)
                .IsRequired(false);

            builder.Property(p => p.SaveForNextTime)
                .IsRequired(false);

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Address1)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.Address2)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.ActivityStatus)
                .IsRequired(false);

            builder.Property(p => p.Country)
                .IsRequired(false);

            builder.Property(p => p.State)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.ZipCode)
                .IsRequired(false);

            builder.Property(p => p.FamilyStatus)
                .IsRequired(false);

            builder.Property(p => p.Children)
                .IsRequired(false);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}