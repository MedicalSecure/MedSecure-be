using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(d => d.Id)
                   .HasConversion(riskFactorId => riskFactorId.Value,
                                  dbId => RiskFactorId.Of(dbId));

            builder.HasOne<Register>()
                   .WithMany(d => d.Disease)
                   .HasForeignKey(w => w.RegisterId);

            builder.HasOne<Register>()
                   .WithMany(d => d.Allergy)
                   .HasForeignKey(w => w.RegisterId).IsRequired(); ;

            builder.HasOne<Register>()
                   .WithMany(d => d.Familymedicalhistory)
                   .HasForeignKey(w => w.RegisterId).IsRequired(); ;

            builder.HasOne<Register>()
                   .WithMany(d => d.PersonalMedicalHistory)
                   .HasForeignKey(w => w.RegisterId).IsRequired(); ;

            builder.HasOne<RiskFactor>()
                   .WithMany(d => d.SubRiskfactory)
                   .HasForeignKey(w => w.RiskFactorId).IsRequired(); ;

            builder.Property(wi => wi.Key)
                   .IsRequired();

            builder.Property(wi => wi.Value)
                   .IsRequired();
        }
    }
}
