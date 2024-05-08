namespace Prescription.Infrastructure.Database.Configurations
{
    internal class DispenseConfiguration : IEntityTypeConfiguration<Dispense>
    {
        public void Configure(EntityTypeBuilder<Dispense> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .HasConversion(DispenseId => DispenseId.Value,
                                           dbId => DispenseId.Of(dbId));

            builder.OwnsOne(d => d.AfterMeal);
            builder.OwnsOne(d => d.BeforeMeal);
        }
    }
}