namespace Prescription.Application.Features.Diagnosis.Commands.DeleteDiagnosis
{
    public class DeleteDiagnosisHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<DeleteDiagnosisCommand, DeleteDiagnosisResult>
    {
        public async Task<DeleteDiagnosisResult> Handle(DeleteDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var diagnosisDto = request.Diagnosis;
            var diagnosis = Domain.Entities.Diagnosis.Create(DiagnosisId.Of(diagnosisDto.Id), diagnosisDto.Code, diagnosisDto.Name, diagnosisDto.ShortDescription, diagnosisDto.LongDescription);

            dbContext.Diagnosis.Remove(diagnosis);

            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Entities.Activity.Create(createdBy, $"Deleted a {nameof(Diagnosis)}", "Hammadi AZ");
            dbContext.Activities.Add(newActivity);

            await dbContext.SaveChangesAsync(cancellationToken);

            // Check if the feature for using message broker is enabled
            if (await featureManager.IsEnabledAsync("DiagnosisSharedFulfilment"))
            {
                // Adapt the command.Diet object to a DiagnosisPlanSharedEvent and publish it
                var eventMessage = request.Diagnosis.Adapt<DiagnosisDeletedSharedEvent>();
                await publishEndpoint.Publish(eventMessage, cancellationToken);
            }

            // return result containing the ID of the deleted diagnosis
            return new DeleteDiagnosisResult(diagnosisDto.Id);
        }
    }
}