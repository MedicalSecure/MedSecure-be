using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(p => p.Id);

            // Configure primary key to use Value property of HistoryId
            builder.Property(p => p.Id)
                   .HasConversion(historyId => historyId.Value,
                                  dbId => HistoryId.Of(dbId));

            // Configure the Date property
            builder.Property(h => h.Date)
                   .IsRequired();

            // Configure Status property
            builder.Property(t => t.Status)
                   .HasConversion(
                       v => v.ToString(), // Convert enum to string
                       status => (Status)Enum.Parse(typeof(Status), status) // Convert string to enum
                   );

            // Configure the relationship with Register
           /* builder.HasOne<Register>()
                   .WithMany(d => d.History)
                   .HasForeignKey(w => w.RegisterId)
                   .IsRequired();*/
        }
    }
}
