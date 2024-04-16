

namespace Visit.Application.Visits.Commands.UpdateVisit;
public class UpdateVisitHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateVisitCommand, UpdateVisitResult>
{
    public async Task<UpdateVisitResult> Handle(UpdateVisitCommand command, CancellationToken cancellationToken)
    {
        var visitId = VisitId.Of(command.Visit.Id);
        var visit = await dbContext.Visits.FindAsync([visitId], cancellationToken);

       //verfier s'il exist visit
        if (visit == null)
        {
            throw new VisitNotFoundException(command.Visit.Id);
        }

        //update Visit entity
        UpdateVisitWithNewValues(visit, command.Visit);
        dbContext.Visits.Update(visit);

        //save to database
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateVisitResult(true);
    }
    private static void UpdateVisitWithNewValues(Domain.Models.Visit visit,VisitDto visitDto)
    {
        visit.UpdateVisit(visitDto.StartDate,visitDto.EndDate, PatientId.Of(visitDto.PatientId), DoctorId.Of(visitDto.DoctorId), visitDto.Title,visitDto.TypeVisit,visitDto.LocationVisit, visitDto.Duration,visitDto.Description,visitDto.Availability);
    }
}
