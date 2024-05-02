﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
namespace BacPatient.Infrastructure.Data.Configurations
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
            builder.Property(p => p.PatientName)
                .HasMaxLength(100);

            // Configure navigation properties
            builder.OwnsOne(p => p.Register, register =>
            {
                register.Property(r => r.familymedicalhistory)
                    .HasConversion(new RiskFactorListConverter()).IsRequired(false);

                register.Property(r => r.personalMedicalHistory)
                    .HasConversion(new RiskFactorListConverter()).IsRequired(false);
            });

            builder.OwnsOne(p => p.RiskFactor, riskFactor =>
            {
                riskFactor.Property(r => r.key).IsRequired(false); ;

                riskFactor.Property(r => r.value).IsRequired(false); ;

                riskFactor.Property(r => r.subRiskfactory)
                    .HasConversion(new RiskFactorListConverter()).IsRequired(false); ;
            });

            builder.OwnsOne(p => p.Disease, disease =>
            {
                disease.Property(d => d.key).IsRequired(false); ;

                disease.Property(d => d.value).IsRequired(false); ;

                disease.Property(d => d.subRiskfactory)
                    .HasConversion(new RiskFactorListConverter()).IsRequired(false); ;
            });
        }
    }
}