

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
        visit.UpdateVisit(visitDto.StartDate,
            visitDto.EndDate, 
            visitDto.Title,
            DoctorId.Of(visitDto.DoctorId),
            Patient.Create(
            PatientId.Of(visitDto.Patient.Id),
            visitDto.Patient.FirstName,
            visitDto.Patient.LastName,
            visitDto.Patient.DateOfBirth,
            visitDto.Patient.CIN,
            visitDto.Patient.CNAM,
            visitDto.Patient.Gender,
            visitDto.Patient.Height,
            visitDto.Patient.Weight,
            visitDto.Patient.Email,
            visitDto.Patient.Address1,
            visitDto.Patient.Address2,
            visitDto.Patient.Country,
            visitDto.Patient.State,
            visitDto.Patient.FamilyStatus,
            visitDto.Patient.Children),
            visitDto.TypeVisit,
            visitDto.LocationVisit, 
            visitDto.Duration,
            visitDto.Description,
            visitDto.Availability);
    }
}
