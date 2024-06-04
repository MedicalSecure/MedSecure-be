namespace UnitCare.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateTaskCommand, CreateTaskResult>
    {
        public async Task<CreateTaskResult> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            // create Task entity from command object
            var task = CreateNewTask(command.Task);

            // save to database
            dbContext.Tasks.Add(task);

            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Models.Activity.Create(createdBy, $"Created new {nameof(task)}", "Ranim.M");
            dbContext.Activities.Add(newActivity);
            try
            {

                await dbContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception x)
            {

                throw x;
            }

            // Check if the feature for using message broker is enabled
            if (await featureManager.IsEnabledAsync("TaskPlanSharedFulfillment"))
            {
                // Adapt the command.Task object to a DietPlanSharedEvent and publish it
                var eventMessage = command.Task.Adapt<DietPlanSharedEvent>();
                await publishEndpoint.Publish(eventMessage, cancellationToken);
            }

            // return result containing the ID of the created task
            return new CreateTaskResult(task.Id.Value);
        }

        private static Domain.Models.Task CreateNewTask(TaskDto taskDto)
        {
            var newTask = Domain.Models.Task.Create(
                id: TaskId.Of(Guid.NewGuid()),
                content: taskDto.Content,
                taskState: taskDto.TaskState,
                taskAction: taskDto.TaskAction
                );


            return newTask;
        }
    }

}