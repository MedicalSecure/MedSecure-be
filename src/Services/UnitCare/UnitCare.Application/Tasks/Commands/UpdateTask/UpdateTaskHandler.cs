using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.UnitCares.Commands.UpdateUnitCare;

namespace UnitCare.Application.Tasks.Commands.UpdateTask;


public class UpdateTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult>
{
    public async Task<UpdateTaskResult> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
    {
        // Update Task entity from command object
        // save to database
        // return result
        var taskId = TaskId.Of(command.Task.Id);
        var task = await dbContext.Tasks.FindAsync([taskId], cancellationToken);

        if (task == null)
        {
            throw new UnitCareNotFoundException(command.Task.Id);
        }

        UpdateTaskWithNewValues(task, command.Task);

        Guid createdBy = Guid.NewGuid();
        var newActivity = Domain.Models.Activity.Create(createdBy, $"updated new {nameof(task)}", "Ranim.M");
        dbContext.Activities.Add(newActivity);

        dbContext.Tasks.Update(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTaskResult(true);
    }

    private static void UpdateTaskWithNewValues(Domain.Models.Task task, TaskDto taskDto)
    {
        task.Update(taskDto.Content, taskDto.TaskState, taskDto.TaskAction);
    }
}
