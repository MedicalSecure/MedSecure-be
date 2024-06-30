using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Diets.Commands.DeleteDiet
{
    public record DeleteDietCommand(Guid Id) : ICommand<DeleteDietResult>;
    public record DeleteDietResult(bool IsSuccess);

    public class DeleteUnitCareCommandValidator : AbstractValidator<DeleteDietCommand>
    {
       
    }
}
