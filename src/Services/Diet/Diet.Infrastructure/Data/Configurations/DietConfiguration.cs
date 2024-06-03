﻿
namespace Diet.Infrastructure.Data.Configurations;

public class DietConfiguration : IEntityTypeConfiguration<Domain.Models.Diet>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Diet> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
               .HasConversion(dietId => dietId.Value,
                              dbId => DietId.Of(dbId));
        builder.Property(d => d.DietType).HasDefaultValue(DietType.Normal).
            HasConversion(
            dt => dt.ToString(),
            dietType => (DietType)Enum.Parse(typeof(DietType), dietType));

        builder.Property(wi => wi.StartDate)
               .IsRequired();

        builder.HasMany(d => d.DailyMeals)
                .WithOne()
                .HasForeignKey(dm => dm.DietId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        builder.Property(wi => wi.EndDate)
              .IsRequired();
    }
}