using MassTransit;
using Microsoft.FeatureManagement;
using Prescription.Application.Contracts;

namespace Prescription.Application.Features.Symptom.Commands.DeleteSymptom
{
    public class DeleteSymptomHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<DeleteSymptomCommand, DeleteSymptomResult>
    {
        public async Task<DeleteSymptomResult> Handle(DeleteSymptomCommand request, CancellationToken cancellationToken)
        {
            var SymptomDto = request.Symptom;
            var Symptom = Domain.Entities.Symptom.Create(SymptomId.Of(SymptomDto.Id), SymptomDto.Code, SymptomDto.Name, SymptomDto.ShortDescription, SymptomDto.LongDescription);

            dbContext.Symptoms.Remove(Symptom);

            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Entities.Activity.Create(createdBy, $"Removed a {nameof(Symptom)}", "Hammadi AZ");
            dbContext.Activities.Add(newActivity);

            await dbContext.SaveChangesAsync(cancellationToken);

            /* // Check if the feature for using message broker is enabled
             if (await featureManager.IsEnabledAsync("SymptomSharedFulfilment"))
             {
                 // Adapt the command.Diet object to a SymptomPlanSharedEvent and publish it
                 var eventMessage = command.Diet.Adapt<SymptomPlanSharedEvent>();
                 await publishEndpoint.Publish(eventMessage, cancellationToken);
             }*/

            // return result containing the ID of the deleted Symptom
            return new DeleteSymptomResult(SymptomDto.Id);
        }
    }
}