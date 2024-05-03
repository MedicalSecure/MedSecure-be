using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.UnitCares.Commands.CreateUnitCare;

namespace UnitCare.Application.UnitCares.Commands.DeleteUnitCare
{
    public record DeleteUnitCareCommand(Guid Id) : ICommand<DeleteUnitCareResult>;
    public record DeleteUnitCareResult(bool IsSuccess);

    public class DeleteUnitCareCommandValidator : AbstractValidator<DeleteUnitCareCommand>
    {
        public DeleteUnitCareCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be provided");
        }
    }

}
