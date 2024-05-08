using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System.Text.Json;

namespace Prescription.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public HistoryConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                  .HasConversion(HistoryId => HistoryId.Value,
                             dbId => HistoryId.Of(dbId));

            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(d => d.Status).HasDefaultValue(Status.Registered)
                .HasConversion(
                    dt => dt.ToString(),
                    status => (Status)Enum.Parse(typeof(Status), status));
        }
    }
}