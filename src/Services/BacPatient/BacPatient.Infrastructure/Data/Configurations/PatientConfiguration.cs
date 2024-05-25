using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BacPatient.Domain.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BacPatient.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class RiskFactorListConverter : ValueConverter<List<RiskFactor?>, string>
    {
        public RiskFactorListConverter() : base(
            riskFactors => JsonSerializer.Serialize(riskFactors, new JsonSerializerOptions { /* Add any necessary options */ }),
            json => JsonSerializer.Deserialize<List<RiskFactor>>(json, new JsonSerializerOptions { /* Add any necessary options */ })
        )
        {
        }
    }

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Patient> builder)
    
        {
            builder.HasKey(p => p.Id);

            // Configure primary key to use Value property of PatientId
            builder.Property(p => p.Id)
                   .HasConversion(patientId => patientId.Value,
                                  dbId => PatientId.Of(dbId));

            builder.Property(p => p.FirstName)
                   .HasMaxLength(50);

            builder.Property(p => p.LastName)
                   .HasMaxLength(50);

            builder.Property(p => p.DateOfBirth);

            builder.Property(p => p.Identity)
                   .HasMaxLength(8);

            builder.Property(p => p.CNAM)
                   .HasMaxLength(20);


            builder.Property(p => p.Email)
                       .HasMaxLength(100)
                       .HasAnnotation("RegularExpression", new Regex(@"^[\w.-]+@([\w-]+\.)+[\w-]{2,4}$").ToString()); // Strict email format validation

            // Configure Gender property
            builder.Property(t => t.Gender).HasDefaultValue(Gender.Other)
                   .HasConversion(
                       v => v.ToString(), // Convert enum to string
                       gender => (Gender)Enum.Parse(typeof(Gender), gender) // Convert string to enum
                   );

            builder.Property(p => p.Height);

            builder.Property(p => p.Weight);

            builder.Property(p => p.Address1)
                   .HasMaxLength(50);

            builder.Property(p => p.Address2)
                   .HasMaxLength(50);

            builder.Property(p => p.State);


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
}