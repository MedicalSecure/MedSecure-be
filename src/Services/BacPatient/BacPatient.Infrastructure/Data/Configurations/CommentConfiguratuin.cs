

namespace BacPatient.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.Label)
            .HasMaxLength(30);

            builder.Property(d => d.Content)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}