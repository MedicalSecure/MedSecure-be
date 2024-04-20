using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Symptom.Commands.UpdateSymptom
{
    public record UpdateSymptomCommand(SymptomDto Symptom) : ICommand<UpdateSymptomResult>;

    public record UpdateSymptomResult(Guid Id);

    public class UpdateSymptomCommandValidator : AbstractValidator<UpdateSymptomCommand>
    {
        public UpdateSymptomCommandValidator()
        {
            /*RuleFor(x => x.Symptom.FirstName).NotEmpty().WithMessage("Symptom.FirstName is required");
            RuleFor(x => x.Symptom.LastName).NotEmpty().WithMessage("Symptom.LastName is required");*/
        }
    }
}