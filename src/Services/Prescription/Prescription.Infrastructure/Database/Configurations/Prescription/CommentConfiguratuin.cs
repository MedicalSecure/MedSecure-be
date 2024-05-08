using Prescription.Domain.Entities;
using Prescription.Domain.Entities.RegisterRoot;
using Prescription.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Infrastructure.Database.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
            .HasConversion(CommentId => CommentId.Value,
                                  dbId => CommentId.Of(dbId));

            builder.Property(d => d.Label)
            .HasMaxLength(30);

            builder.Property(d => d.Content)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}