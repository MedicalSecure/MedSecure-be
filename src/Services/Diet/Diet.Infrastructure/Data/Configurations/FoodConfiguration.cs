namespace Diet.Infrastructure.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
               .HasConversion(mealId => mealId.Value,
                              dbId => FoodId.Of(dbId));

        builder.Property(wi => wi.Name).HasMaxLength(255)
               .IsRequired();

        builder.Property(wi => wi.Description).HasMaxLength(500)
              .IsRequired();

        builder.Property(wi => wi.Calories).HasDefaultValue(0)
             .IsRequired();
    }
}
