using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Infrastructure.Data.Configurations;


public class TaskConfiguration : IEntityTypeConfiguration<Domain.Models.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasConversion(taskId => taskId.Value,
                              dbId => TaskId.Of(dbId));


        builder.Property(t => t.Content)
                      .IsRequired();

        builder.Property(t => t.TaskState)
               .IsRequired();

        builder.Property(t => t.TaskAction)
              .IsRequired();

    


    }
}
