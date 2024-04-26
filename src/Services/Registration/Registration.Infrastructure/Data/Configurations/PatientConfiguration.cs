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

            builder.Property(mi => mi.Id)
                   .HasConversion(registerId => registerId.Value,
                                  dbId => PatientId.Of(dbId));

            builder.Property(wi => wi.FirstName).HasMaxLength(50)
                   .IsRequired();
            builder.Property(wi => wi.LastName).HasMaxLength(50)
                   .IsRequired();

            builder.Property(wi => wi.DateOfBirth)
                   .IsRequired();
            builder.Property(wi => wi.CIN).HasMaxLength(8)
                   .IsRequired();
            builder.Property(wi => wi.CNAM).HasMaxLength(20)
                   .IsRequired();

            builder.Property(mi => mi.Gender).HasDefaultValue(Gender.Other)
                   .HasConversion(
                       mi => mi.ToString(),
                       gender => (Gender)Enum.Parse(typeof(Gender), gender));

            builder.Property(wi => wi.Height)
                   .IsRequired();

            builder.Property(wi => wi.Weight)
                   .IsRequired();
            builder.Property(wi => wi.Address1).HasMaxLength(50);
            builder.Property(wi => wi.Address2).HasMaxLength(50);
            builder.Property(wi => wi.Country).IsRequired();
            builder.Property(wi => wi.State).IsRequired();
            builder.Property(mi => mi.FamilyStatus).HasDefaultValue(FamilyStatus.SINGLE)
                  .HasConversion(
                      mi => mi.ToString(),
                      familyStatus => (FamilyStatus)Enum.Parse(typeof(FamilyStatus), familyStatus));
            builder.Property(mi => mi.Children).HasDefaultValue(Children.None)
                 .HasConversion(
                     mi => mi.ToString(),
                     children => (Children)Enum.Parse(typeof(Children), children));



        }
    }
}
