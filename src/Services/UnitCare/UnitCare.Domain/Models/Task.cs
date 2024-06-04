namespace UnitCare.Domain.Models
{
    public class Task : Aggregate<TaskId>
    {
        public string Content { get; private set; } = default!;
        public TaskState TaskState { get; private set; } = default!;
        public TaskAction TaskAction { get; private set; } = default!;

      
        public static Task Create(
            TaskId id,
            string content,
            TaskState taskState,
            TaskAction taskAction
            )
        {
            var task = new Task()
            {
                Id = id,
                Content = content,
                TaskState = taskState,
                TaskAction = taskAction

            };

            task.AddDomainEvent(new TaskCreatedEvent(task));

            return task;
        }

        public void Update(

            string content,
            TaskState taskState,
            TaskAction taskAction

         )
        {

            Content = content;
            TaskState = taskState;
            TaskAction = taskAction;
            

            AddDomainEvent(new TaskUpdatedEvent(this));
        }


    }

}

