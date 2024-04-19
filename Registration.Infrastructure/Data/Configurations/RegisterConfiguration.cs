using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(mi => mi.Id);

            builder.Property(wi => wi.Familymedicalhistory)
                  .IsRequired();

            builder.Property(wi => wi.PersonalMedicalHistory)
                .IsRequired();
        }
    }
}