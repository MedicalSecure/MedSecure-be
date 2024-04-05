//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Visit.Domain.Events;

//namespace Visit.Application.Doctors.EventHandlers.Domain;

//public class DoctorCreatedEventHandler(ILogger<DoctorCreatedEventHandler> logger)
//    : INotificationHandler<DoctorCreatedEvent>
//{
//    public Task Handle(DoctorCreatedEvent notification, CancellationToken cancellationToken)
//    {
//        // Log that the domain event is being handled
//        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

//        // Return a completed task since there is no further asynchronous work to be done
//        return Task.CompletedTask;
//    }

//}