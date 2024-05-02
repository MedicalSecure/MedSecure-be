namespace BacPatient.Infrastructure.Data.Configurations
{
    public class SymptomConfiguration : IEntityTypeConfiguration<Symptom>
    {
        public void Configure(EntityTypeBuilder<Symptom> builder)
        {
            builder.HasKey(x => x.Id);

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