using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand(TaskDto Task) : ICommand<CreateTaskResult>;

    public record CreateTaskResult(Guid Id);

    public class CreateUnitCareCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateUnitCareCommandValidator()
        {
            RuleFor(x => x.Task.Content).NotEmpty().WithMessage("Content should not be empty");
            RuleFor(x => x.Task.TaskAction).NotEmpty().WithMessage("TaskAction is required");
            RuleFor(x => x.Task.TaskState).NotEmpty().WithMessage("TaskState is should not be empty");
    
        }
    }

}
