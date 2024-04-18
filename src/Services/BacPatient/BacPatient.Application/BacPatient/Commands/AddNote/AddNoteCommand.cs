
namespace BacPatient.Application.BacPatient.Commands.AddNote
{
    public record AddNoteCommand(Guid Id, string Note) : ICommand<AddNoteResult>;

    public record AddNoteResult(bool IsSuccess);
  
}
