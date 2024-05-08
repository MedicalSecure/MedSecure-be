using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Registration.Infrastructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        // Configure primary key to use Value property of PatientId
        builder.Property(p => p.Id)
               .HasConversion(patientId => patientId.Value,
                              dbId => PatientId.Of(dbId));

        builder.Property(p => p.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.DateOfBirth)
               .IsRequired();

        builder.Property(p => p.Identity)
               .HasMaxLength(8)
               .IsRequired();

        builder.Property(p => p.CNAM)
               .HasMaxLength(20);

        builder.Property(p => p.Assurance)
               .HasMaxLength(20);

        builder.Property(p => p.Email)
                   .HasMaxLength(100) // Update to appropriate max length
                   .IsRequired()
                   .HasAnnotation("RegularExpression", new Regex(@"^[\w.-]+@([\w-]+\.)+[\w-]{2,4}$").ToString()); // Strict email format validation

        // Configure Gender property
        builder.Property(t => t.Gender).HasDefaultValue(Gender.Other)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string
                   gender => (Gender)Enum.Parse(typeof(Gender), gender) // Convert string to enum
               );

        builder.Property(p => p.Height)
               .IsRequired();

        builder.Property(p => p.Weight)
               .IsRequired();

        builder.Property(p => p.Address1)
               .HasMaxLength(50);

        builder.Property(p => p.Address2)
               .HasMaxLength(50);

        builder.Property(p => p.State)
               .IsRequired();


        // Configure ActivityStatus property
        builder.Property(t => t.ActivityStatus).HasDefaultValue(ActivityStatus.HIGH)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string
                   activityStatus => (ActivityStatus)Enum.Parse(typeof(ActivityStatus), activityStatus) // Convert string to enum
               );

        // Configure FamilyStatus property
        builder.Property(t => t.FamilyStatus).HasDefaultValue(FamilyStatus.SINGLE)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string
                   familyStatus => (FamilyStatus)Enum.Parse(typeof(FamilyStatus), familyStatus) // Convert string to enum
               );

        // Configure Children property
        builder.Property(t => t.Children).HasDefaultValue(Children.None)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string
                   children => (Children)Enum.Parse(typeof(Children), children) // Convert string to enum
               );

        // Configure Country property
        builder.Property(t => t.Country).HasDefaultValue(Country.TN)
               .HasConversion(
                   v => v.ToString(), // Convert enum to string
                   country => (Country)Enum.Parse(typeof(Country), country) // Convert string to enum
               );
    }
}
