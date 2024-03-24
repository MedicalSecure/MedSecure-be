
namespace Diet.Infrastructure.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
               .HasConversion(foodId => foodId.Value,
                              dbId => FoodId.Of(dbId));

        builder.HasOne<Meal>()
               .WithMany(d => d.Foods)
               .HasForeignKey(w => w.MealId);

        builder.Property(wi => wi.Name).HasMaxLength(255)
               .IsRequired();

        builder.Property(wi => wi.Description).HasMaxLength(500)
              .IsRequired();

        builder.Property(wi => wi.Calories).HasDefaultValue(0)
             .IsRequired();
    }
}
