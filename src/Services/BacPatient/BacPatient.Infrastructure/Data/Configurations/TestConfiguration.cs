using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(t => t.Id);

            // Configure primary key to use Value property of TestId
            builder.Property(w => w.Id)
                   .HasConversion(testId => testId.Value,
                                  dbId => TestId.Of(dbId));

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(255);

            // Configure Language property
            builder.Property(t => t.Language).HasDefaultValue(Language.English)
                    .HasConversion(
                    l => l.ToString(),  // Convert enum to string
                    language => (Language)Enum.Parse(typeof(Language), language));  // Convert string to enum

            // Configure TestType property
            builder.Property(t => t.Type).HasDefaultValue(TestType.Other)
                   .HasConversion(
                       v => v.ToString(), // Convert enum to string
                       testType => (TestType)Enum.Parse(typeof(TestType), testType) // Convert string to enum
                   );

            // Configure many-to-one relationship with Register for Test
            builder.HasOne<Register>()
                      .WithMany(r => r.Tests)
                      .HasForeignKey(rf => rf.RegisterId)
                      .IsRequired();
        }
    }
}