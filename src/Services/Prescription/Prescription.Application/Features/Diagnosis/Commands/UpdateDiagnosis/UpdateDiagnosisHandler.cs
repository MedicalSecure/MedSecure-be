using Prescription.Application.Contracts;
using Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prescription.Application.Exceptions;

namespace Prescription.Application.Features.Diagnosis.Commands.UpdateDiagnosis
{
    public class UpdateDiagnosisHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateDiagnosisCommand, UpdateDiagnosisResult>
    {
        public async Task<UpdateDiagnosisResult> Handle(UpdateDiagnosisCommand command, CancellationToken cancellationToken)
        {
            // Update Diagnosis entity from command object
            // save to database
            // return result
            var Diagnosis = await dbContext.Diagnosis.FindAsync([command.Diagnosis.Id], cancellationToken);

            if (Diagnosis == null)
            {
                throw new DiagnosisNotFoundException(command.Diagnosis.Id);
            }

            UpdateDiagnosisWithNewValues(Diagnosis, command.Diagnosis);
            dbContext.Diagnosis.Update(Diagnosis);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateDiagnosisResult(Diagnosis.Id);
        }

        private static void UpdateDiagnosisWithNewValues(Domain.Entities.Diagnosis diagnosis, DiagnosisDto diagnosisDto)
        {
            diagnosis.Update(diagnosisDto.Code, diagnosisDto.Name, diagnosisDto.ShortDescription, diagnosisDto.LongDescription);
        }
    }
}