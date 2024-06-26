﻿

namespace Visit.Application.Visits.Commands.DeleteVist;

public class DeleteVisitHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteVisitCommand, DeleteVisitResult>
{
    public async Task<DeleteVisitResult> Handle(DeleteVisitCommand command, CancellationToken cancellationToken)
    {
        var visitId = VisitId.Of(command.Id);
        var visit = await dbContext.Visits.FindAsync([visitId], cancellationToken);

        // Check if visit exists

        if (visit == null)
        {
            throw new VisitNotFoundException(command.Id);
        }
        // Delete visit
        dbContext.Visits.Remove(visit);

        //add activity
        Guid createdBy = Guid.NewGuid();
        var newActivity = Domain.Models.Activity.Create(createdBy, "delated visits", "Chadha Jamel");
        dbContext.Activities.Add(newActivity);
        //save to database
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteVisitResult(true);


    }

}