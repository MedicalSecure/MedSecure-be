using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Infrastructure.Data.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.Content)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.CreatorName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .IsRequired();
        }
    }
}