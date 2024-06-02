using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Registration.Infrastructure.Data.Configurations
{
    public class RiskFactorConfiguration : IEntityTypeConfiguration<RiskFactor>
    {
        public void Configure(EntityTypeBuilder<RiskFactor> builder)
        {
            builder.HasKey(x => x.Id);

            // Configure primary key to use Value property of RiskFactorId
            builder.Property(r => r.Id)
                   .HasConversion(riskFactorId => riskFactorId.Value,
                                  dbId => RiskFactorId.Of(dbId));

            builder.Property(p => p.RiskFactorParentId)
           .HasConversion(
               new ValueConverter<RiskFactorId?, Guid?>(
                   modelRiskFactorId => modelRiskFactorId == null ? null : modelRiskFactorId.Value,
                   dbRiskFactorId => dbRiskFactorId.HasValue ? RiskFactorId.OfNullable(dbRiskFactorId.Value) : null
               ),
               new ValueComparer<RiskFactorId?>(
                   (RiskFactorId1, RiskFactorId2) => RiskFactorId1 == null && RiskFactorId2 == null || RiskFactorId1 != null && RiskFactorId2 != null && RiskFactorId1.Value == RiskFactorId2.Value,
                   RiskFactorId => RiskFactorId == null ? 0 : RiskFactorId.Value.GetHashCode(),
                   RiskFactorId => RiskFactorId ?? RiskFactorId.Of(Guid.Empty)
               )
           );

            builder.HasMany(d => d.SubRiskFactors)
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