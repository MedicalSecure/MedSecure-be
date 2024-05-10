using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Data.Configurations
{
   
    public class DispenseConfiguration : IEntityTypeConfiguration<Domain.Models.Dispense>
    {

        public void Configure(EntityTypeBuilder<Dispense> builder)
        {

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Id)
                  .HasConversion(personnelId => personnelId.Value,
                                 dbId => DispenseId.Of(dbId));
        }
    }
        }
