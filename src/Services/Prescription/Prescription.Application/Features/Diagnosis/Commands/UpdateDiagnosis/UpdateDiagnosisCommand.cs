using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Diagnosis.Commands.UpdateDiagnosis
{
    public record UpdateDiagnosisCommand(DiagnosisDTO Diagnosis) : ICommand<UpdateDiagnosisResult>;

    public record UpdateDiagnosisResult(Guid Id);

    public class UpdateDiagnosisCommandValidator : AbstractValidator<UpdateDiagnosisCommand>
    {
        public UpdateDiagnosisCommandValidator()
        {
            /*RuleFor(x => x.Diagnosis.FirstName).NotEmpty().WithMessage("Diagnosis.FirstName is required");
            RuleFor(x => x.Diagnosis.LastName).NotEmpty().WithMessage("Diagnosis.LastName is required");*/
        }
    }
}