using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System.Text.Json;

namespace Prescription.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public TestConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                  .HasConversion(TestId => TestId.Value,
                             dbId => TestId.Of(dbId));

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(d => d.Type).HasDefaultValue(TestType.ClinicTest)
                .HasConversion(
                    dt => dt.ToString(),
                    testType => (TestType)Enum.Parse(typeof(TestType), testType));

            builder.Property(d => d.Language).HasDefaultValue(Language.English)
                .HasConversion(
                    dt => dt.ToString(),
                    lang => (Language)Enum.Parse(typeof(Language), lang));
        }
    }
}