

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(medication => medication.Id);

            builder.Property(m => m.Name)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(m => m.Price)
            .HasColumnType("decimal(18,4)");

            builder.Property(m => m.Dosage)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Form)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Unit)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(m => m.Description)
                .IsRequired();

            builder.Property(m => m.ExpiredAt)
                .IsRequired();
        }
    }
}