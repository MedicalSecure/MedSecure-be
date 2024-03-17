
namespace Diet.Infrastructure.Data.Configurations;

public class DietConfiguration : IEntityTypeConfiguration<Domain.Models.Diet>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Diet> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
               .HasConversion(dietId => dietId.Value,
                              dbId => DietId.Of(dbId));

        builder.HasOne<Patient>()
              .WithMany()
              .HasForeignKey(w => w.PatientId);

        builder.Property(d => d.DietType).HasDefaultValue(DietType.Normal).
            HasConversion(
            dt => dt.ToString(),
            dietType => (DietType)Enum.Parse(typeof(DietType), dietType));

        builder.Property(wi => wi.StartDate)
               .IsRequired();

        builder.Property(wi => wi.EndDate)
              .IsRequired();
    }
}