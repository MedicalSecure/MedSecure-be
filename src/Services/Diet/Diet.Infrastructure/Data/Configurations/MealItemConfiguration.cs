namespace Diet.Infrastructure.Data.Configurations;

public class MealItemConfiguration : IEntityTypeConfiguration<MealItem>
{
    public void Configure(EntityTypeBuilder<MealItem> builder)
    {
        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.Id)
               .HasConversion(mealItemId => mealItemId.Value,
                                dbId => MealItemId.Of(dbId));

        builder.HasOne<Food>()
                .WithMany()
                .HasForeignKey(mi => mi.FoodId);

        builder.HasOne<Meal>()
                .WithMany(m => m.MealItems) 
                .HasForeignKey(mi => mi.MealId);

        builder.Property(mi => mi.MealCategory).HasDefaultValue(MealCategory.MainCourses)
                .HasConversion(
                mi => mi.ToString(),
                mealCategory => (MealCategory)Enum.Parse(typeof(MealCategory), mealCategory));
    }
}