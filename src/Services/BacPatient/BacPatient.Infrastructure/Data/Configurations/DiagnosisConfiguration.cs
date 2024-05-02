
namespace BacPatient.Infrastructure.Data.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.Property(d => d.Code)
            .HasMaxLength(50);

            builder.Property(d => d.Name)
                .HasMaxLength(50).IsRequired();

            builder.Property(d => d.ShortDescription)
                .HasMaxLength(100);

            builder.Property(d => d.LongDescription)
                .HasMaxLength(250);
        }
    }
}