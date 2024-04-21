using BuildingBlocks.CQRS;
using Pharmalink.Application.Data;
using Pharmalink.Application.Dtos;
using Pharmalink.Domain.Models;
using Pharmalink.Domain.ValueObjects;

namespace Pharmalink.Application.Medications.Commands.CreateMedication;

public class CreateMedicationHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateMedicationCommand, CreateMedicationResult>
{
    public async Task<CreateMedicationResult> Handle(CreateMedicationCommand command, CancellationToken cancellationToken)
    {
        // create medication entity from command object
        // save to database
        // return result

        var medictaion = CreateNewMedication(command.Medication);

        dbContext.Medications.Add(medictaion);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateMedicationResult(medictaion.Id.Value);
    }

    private static Medication CreateNewMedication(MedicationDto medicationDto)
    {
        var newMedication = Medication.Create(
            id: MedicationId.Of(Guid.NewGuid()),
            name: medicationDto.Name,
            dosage: medicationDto.Dosage,
            form: medicationDto.Form,
            code: medicationDto.Code,
            unit: medicationDto.Unit,
            description: medicationDto.Description,
            expiredAt: medicationDto.ExpiredAt,
            stock: medicationDto.Stock,
            alertStock: medicationDto.AlertStock,
            avrgStock: medicationDto.AvrgStock,
            minStock: medicationDto.MinStock,
            safetyStock: medicationDto.SafetyStock,
            reservedStock: medicationDto.ReservedStock,
            price: medicationDto.Price
            );

        return newMedication;
    }
}
