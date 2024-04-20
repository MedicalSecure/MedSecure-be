using FluentValidation;
using Prescription.Application.Features.Symptom.Commands.CreateSymptom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Symptom.Commands.DeleteSymptom
{
    public record DeleteSymptomCommand(SymptomDto Symptom) : ICommand<DeleteSymptomResult>;

    public record DeleteSymptomResult(Guid Id);

    public class DeleteSymptomCommandValidator : AbstractValidator<DeleteSymptomCommand>
    {
        public DeleteSymptomCommandValidator()
        {
            RuleFor(x => x.Symptom.Id).NotEqual(Guid.Empty).When(x => string.IsNullOrEmpty(x.Symptom.Code)).WithMessage("At least either Symptom Id or Code must be provided");
            RuleFor(x => x.Symptom.Code).NotEmpty().When(x => x.Symptom.Id == Guid.Empty).WithMessage("At least either Symptom Id or Code must be provided");
        }
    }
}