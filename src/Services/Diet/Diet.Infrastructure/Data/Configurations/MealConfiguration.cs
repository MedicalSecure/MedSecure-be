
namespace Diet.Infrastructure.Data.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
               .HasConversion(mealId => mealId.Value,
                              dbId => MealId.Of(dbId));

      
        builder.Property(wi => wi.Name).HasMaxLength(255)
              .IsRequired();

        builder.Property(d => d.MealType).HasDefaultValue(MealType.Breakfast).
            HasConversion(
            dt => dt.ToString(),
            dietType => (MealType)Enum.Parse(typeof(MealType), dietType));
    }
}
