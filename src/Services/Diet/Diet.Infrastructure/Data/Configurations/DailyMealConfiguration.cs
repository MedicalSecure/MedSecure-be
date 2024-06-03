

namespace Diet.Infrastructure.Data.Configurations
{
    public class DailyMealConfiguration : IEntityTypeConfiguration<Domain.Models.DailyMeal>
    {

        public void Configure(EntityTypeBuilder<Domain.Models.DailyMeal> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .HasConversion(dailymealId => dailymealId.Value,
                                  dbId => DailyMealId.Of(dbId));

            builder.HasMany(dm => dm.Meals)
                          .WithOne() // Assuming Meal has a navigation property to DailyMeal
                          .HasForeignKey(m => m.DailyMealId) // Foreign key on Meal referencing DailyMealId
                          .OnDelete(DeleteBehavior.Cascade)
                          .IsRequired();
        }
    }
}


