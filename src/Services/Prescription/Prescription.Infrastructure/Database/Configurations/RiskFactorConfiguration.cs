using Prescription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Infrastructure.Database.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(d => d.SubRiskFactor)
                    .WithOne(r => r.RiskFactorParent)
                    .HasForeignKey(sub => sub.RiskFactorParentId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Key)
                   .HasMaxLength(128); // Set max length for Key

            builder.Property(x => x.Value)
                   .HasMaxLength(256); // Set max length for Value

            builder.Property(x => x.Code)
                   .HasMaxLength(64); // Set max length for Code

            builder.Property(x => x.Description)
                   .HasMaxLength(512); // Set max length for Description

            builder.Property(x => x.Type)
                   .HasMaxLength(100); // Set max length for Type

            builder.Property(x => x.Icon)
                   .HasMaxLength(500); // Set max length for Icon

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}