using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Tasks.Commands.UpdateTask;


public record UpdateTaskCommand(TaskDto Task) : ICommand<UpdateTaskResult>;

public record UpdateTaskResult(bool IsSuccess);

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
public UpdateTaskCommandValidator()
{
    RuleFor(x => x.Task.Id).NotEmpty().WithMessage("TaskId is required");
    RuleFor(x => x.Task.Content).NotEmpty().WithMessage("Content is required");
    RuleFor(x => x.Task.TaskState).NotEmpty().WithMessage("TaskState is required");
}
}

