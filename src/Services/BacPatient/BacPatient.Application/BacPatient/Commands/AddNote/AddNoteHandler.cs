
using BacPatient.Application.BacPatient.Commands.AddNote;

namespace BacPatient.Application.BacPatient.Commands.AddNote;

public class AddNoteHandler(IApplicationDbContext dbContext) : ICommandHandler<AddNoteCommand, AddNoteResult>
{
    public async Task<AddNoteResult> Handle(AddNoteCommand command, CancellationToken cancellationToken)
    {
        var medId = MedicineId.Of(command.Id);
        var medecines = await dbContext.Medecines.FindAsync([medId], cancellationToken);
        if (medecines == null)
        {
            throw new BPNotFoundException(command.Id);
        }

        AddNoteToMedicine(medecines, command.Note);

        dbContext.Medecines.Update(medecines);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new AddNoteResult(true);
    }

    private static void AddNoteToMedicine(Domain.Models.Medicine med, string Note)
    {
        med.AddNote(Note);
    }
}



