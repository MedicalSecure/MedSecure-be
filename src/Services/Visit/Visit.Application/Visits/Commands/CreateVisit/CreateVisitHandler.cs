

namespace Visit.Application.Visits.Commands.CreateVisit;

public class CreateVisitHandler(IPublishEndpoint publishEndpoint,IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateVisitCommand, CreateVisitResult>
{
    public async Task<CreateVisitResult> Handle(CreateVisitCommand command, CancellationToken cancellationToken)
    {
        var visit = CreateNewVisit(command.Visit);
        dbContext.Visits.Add(visit);
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
            patientId: PatientId.Of(visitDto.PatientId),
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

