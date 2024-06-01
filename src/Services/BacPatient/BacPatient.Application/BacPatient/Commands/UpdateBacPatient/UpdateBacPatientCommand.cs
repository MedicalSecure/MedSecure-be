using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.BacPatient.Commands.UpdateBacPatient
{
    public record UpdateBacPatientCommand(BacPatientDto BacPatient) : ICommand<UpdateBacPatientResult>;

    public record UpdateBacPatientResult(bool IsSuccess);

    public class UpdateBacPatientCommandValidator : AbstractValidator<UpdateBacPatientCommand>
    {
        public UpdateBacPatientCommandValidator()
        {
            RuleFor(x => x.BacPatient.Id).NotEmpty().WithMessage("DietId is required");
        }
    }
}
