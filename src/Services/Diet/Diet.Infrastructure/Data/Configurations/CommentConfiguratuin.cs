

namespace BacPatient.Infrastructure.Database.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
           .HasConversion(personnelId => personnelId.Value,
                          dbId => CommentId.Of(dbId));
            builder.HasOne<Meal>()
              .WithMany(d => d.Comments)
              .HasForeignKey(w => w.MealId);
            builder.Property(d => d.Label)
            .HasMaxLength(30);

            builder.Property(d => d.Content)
                .HasMaxLength(300);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}