using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.Models;

namespace Registration.Infrastructure.Data.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Date)
                   .IsRequired();

            // Assuming Status is an enum
            builder.Property(h => h.Status)
                   .IsRequired()
                   .HasConversion<int>();

            // Assuming AssociatedPatientId is a foreign key
            builder.Property(h => h.AssociatedPatientId)
                   .IsRequired();

            // Relationships
            builder.HasOne(h => h.Patient)  // Use navigation property
                   .WithMany() // Assuming one-to-many relationship
                   .HasForeignKey(h => h.AssociatedPatientId) // Use foreign key property
                   .OnDelete(DeleteBehavior.Cascade);  // Define delete behavior as needed
        }
    }
}
