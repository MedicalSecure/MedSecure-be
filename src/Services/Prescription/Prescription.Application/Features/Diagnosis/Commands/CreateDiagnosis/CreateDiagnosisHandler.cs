using Prescription.Application.Contracts;
using Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis
{
    public class UpdateDiagnosisHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDiagnosisCommand, CreateDiagnosisResult>
    {
        public async Task<CreateDiagnosisResult> Handle(CreateDiagnosisCommand command, CancellationToken cancellationToken)
        {
            // create Diagnosis entity from command object
            // save to database
            // return result
            var Diagnosis = CreateNewDiagnosis(command.Diagnosis);

            dbContext.Diagnosis.Add(Diagnosis);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateDiagnosisResult(Diagnosis.Id.Value);
        }

        private static Domain.Entities.Diagnosis CreateNewDiagnosis(DiagnosisDto DiagnosisDto)
        {
            var newDiagnosis = Domain.Entities.Diagnosis.Create(DiagnosisDto.Code, DiagnosisDto.Name, DiagnosisDto.ShortDescription, DiagnosisDto.LongDescription);
            return newDiagnosis;
        }
    }
}