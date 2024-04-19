using Registration.Domain.Enums;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(mi => mi.Id);

            builder.Property(wi => wi.PatientName).HasMaxLength(50)
                  .IsRequired();

            builder.Property(wi => wi.DateOfBirth)
                .IsRequired();


            builder.Property(mi => mi.Gender).HasDefaultValue(Gender.Other).
                HasConversion(
                mi => mi.ToString(),
                gender => (Gender)Enum.Parse(typeof(Gender), gender));

            builder.Property(wi => wi.Height).HasMaxLength(50)
                .IsRequired();

            builder.Property(wi => wi.Weight).HasMaxLength(50)
                .IsRequired();

            builder.Property(wi => wi.Register)
               .IsRequired();

             builder.Property(wi => wi.RiskFactor)
               .IsRequired();

             builder.Property(wi => wi.Disease)
               .IsRequired();

        }
    }
}
