namespace Pharmalink.Application.Dosages.Commands.CreateDosage;

public class CreateDosageHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDosageCommand, CreateDosageResult>
{
    public async Task<CreateDosageResult> Handle(CreateDosageCommand command, CancellationToken cancellationToken)
    {
        // create dosage entity from command object
        // save to database
        // return result

        var dosagesCreated = CreateNewDosages(command.Dosages);

        dbContext.Dosages.AddRange(dosagesCreated);

        await dbContext.SaveChangesAsync(cancellationToken);

        var createdDosageIds = dosagesCreated.Select(d => d.Id.Value).ToList();

        return new CreateDosageResult(createdDosageIds);

    }

    private static List<Dosage> CreateNewDosages(List<DosageDto> dosagesDto)
    {
        var newDosages = new List<Dosage>();

        foreach (var dosageDto in dosagesDto)
        {
            var newDosage = Dosage.Create(
                id: DosageId.Of(dosageDto.Id),
                code: dosageDto.Code,
                label: dosageDto.Label
            );

            if (newDosage != null)
            {
                newDosages.Add(newDosage);
            }
        }
        return newDosages;
    }
}
