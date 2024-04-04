using MediatR;
using Microsoft.FeatureManagement;

namespace BacPatient.Application.BPModels.Commands.CreateDiet;

public class CreateBPModelHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateBPModelCommand, CreateBPModelResult>
{
    public async Task<CreateBPModelResult> Handle(CreateBPModelCommand command, CancellationToken cancellationToken)
    {
        // create Diet entity from command object
        var diet = CreateNewBP(command.BPModel);

        // save to database
        dbContext.BacPatients.Add(diet);
        await dbContext.SaveChangesAsync(cancellationToken);

        // Check if the feature for using message broker is enabled
        if (await featureManager.IsEnabledAsync("DietPlanSharedFulfillment"))
        {
            // Adapt the command.Diet object to a DietPlanSharedEvent and publish it
            var eventMessage = command.BPModel.Adapt<BPModelPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        // return result containing the ID of the created diet
        return new CreateBPModelResult(diet.Id.Value);
    }

    private static Domain.Models.BPModel CreateNewBP(BPModelDto bPModelDto)
    {
        var newBPModel = Domain.Models.BPModel.Create(
            id: BPModelId.Of(Guid.NewGuid()),
            patientId: PatientId.Of(bPModelDto.PatientId),
            roomId:RoomId.Of(bPModelDto.RoomId) , 
            unitCareId: UnitCareId.Of(bPModelDto.UnitCareId),
            bed: bPModelDto.Bed,
            servingDate : bPModelDto.ServingDate ,
            served: bPModelDto.Served ,
            toServe: bPModelDto.ToServe ,
            status: bPModelDto.Status
            );

        foreach (var medicine in bPModelDto.Medicines)
        {
            var newMed = Medicine.Create(
              MedicineId.Of(medicine.Id),
              medicine.Name,
                 medicine.Form,
                 medicine.dose,
                 medicine.Unit,
                 medicine.DateExp,
                 medicine.Stock,
                 medicine.Note
                );
            newBPModel.AddMedicne(newMed);

        }
        return newBPModel;

    }
}