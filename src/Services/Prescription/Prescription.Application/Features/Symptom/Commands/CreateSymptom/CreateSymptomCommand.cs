using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Symptom.Commands.CreateSymptom
{
    public record CreateSymptomCommand(SymptomDto Symptom) : ICommand<CreateSymptomResult>;

    public record CreateSymptomResult(Guid Id);

    public class CreateSymptomCommandValidator : AbstractValidator<CreateSymptomCommand>
    {
        public CreateSymptomCommandValidator()
        {
            /*RuleFor(x => x.Symptom.FirstName).NotEmpty().WithMessage("Symptom.FirstName is required");
            RuleFor(x => x.Symptom.LastName).NotEmpty().WithMessage("Symptom.LastName is required");*/
        }
    }
}