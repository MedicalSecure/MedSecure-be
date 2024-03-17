
namespace Waste.Infrastructure.Data.Configurations;

public class WasteItemConfiguration : IEntityTypeConfiguration<WasteItem>
{
    public void Configure(EntityTypeBuilder<WasteItem> builder)
    {
        builder.HasKey(wi => wi.Id);

        builder.Property(wi => wi.Id).HasConversion(wasteItemId => wasteItemId.Value,
            dbId => WasteItemId.Of(dbId));

        builder.HasOne<Product>().WithMany().HasForeignKey(wi => wi.ProductId);

        builder.Property(wi => wi.Quntity)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(wi => wi.Weight)
               .IsRequired()
               .HasDefaultValue(0);
    }
}
