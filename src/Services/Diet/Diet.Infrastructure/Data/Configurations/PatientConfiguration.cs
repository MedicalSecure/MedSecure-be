﻿namespace Diet.Infrastructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.Id)
                 .HasConversion(mealFoodId => mealFoodId.Value,
                                dbId => PatientId.Of(dbId));

        builder.Property(wi => wi.FirstName).HasMaxLength(50)
              .IsRequired();

        builder.Property(wi => wi.LastName).HasMaxLength(50)
            .IsRequired();

        builder.Property(wi => wi.DateOfBirth)
            .IsRequired();

        builder.Property(mi => mi.Gender).HasDefaultValue(Gender.Other).
            HasConversion(
            mi => mi.ToString(),
            gender => (Gender)Enum.Parse(typeof(Gender), gender));
    }
}
