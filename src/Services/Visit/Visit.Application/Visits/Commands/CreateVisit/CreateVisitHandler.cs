

using Microsoft.AspNetCore.Http.HttpResults;

namespace Visit.Application.Visits.Commands.CreateVisit;

public class CreateVisitHandler(IPublishEndpoint publishEndpoint,IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateVisitCommand, CreateVisitResult>
{
    public async Task<CreateVisitResult> Handle(CreateVisitCommand command, CancellationToken cancellationToken)
    {
        var visit = CreateNewVisit(command.Visit);
        dbContext.Visits.Add(visit);

        //add activity
        Guid createdBy = Guid.NewGuid();
        var newActivity = Domain.Models.Activity.Create(createdBy, "created new visits", "Chadha Jamel");
        dbContext.Activities.Add(newActivity);
        await dbContext.SaveChangesAsync(cancellationToken);

        // Check if the feature for using message broker is enabled
        if (await featureManager.IsEnabledAsync("VisitPlanSharedFulfillment"))
        {
            // Adapt the command.Diet object to a DietPlanSharedEvent and publish it
            var eventMessage = command.Visit.Adapt<DietPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        // return result containing the ID of the created visits
        return new CreateVisitResult(visit.Id.Value);

    }
    private static Domain.Models.Visit CreateNewVisit(VisitDto visitDto)
    {
        var newvisit = Domain.Models.Visit.CreateVisit(
            id: VisitId.Of(Guid.NewGuid()),
            patient:Patient.Create(
            PatientId.Of(Guid.NewGuid()),
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
            visitDto.Patient.Children
            ),
            doctorId: DoctorId.Of(visitDto.DoctorId),
            title: visitDto.Title,
            startDate: visitDto.StartDate,
            endDate: visitDto.EndDate,
            typeVisit: visitDto.TypeVisit,
            locationVisit: visitDto.LocationVisit,
            duration: visitDto.Duration,
            description : visitDto.Description,
            availability : visitDto.Availability
            );
            return (newvisit);
    }
}
