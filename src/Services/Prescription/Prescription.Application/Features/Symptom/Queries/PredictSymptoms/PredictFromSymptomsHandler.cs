using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Extensions;
using Prescription.Services.PredictBySymptomsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public class PredictFromSymptomsHandler(IApplicationDbContext dbContext) : IQueryHandler<PredictFromSymptomsQuery, PredictFromSymptomsResult>
    {
        public async Task<PredictFromSymptomsResult> Handle(PredictFromSymptomsQuery query, CancellationToken cancellationToken)
        {
            // get Symptom with pagination
            // return result
            var symptomsList = query.Symptoms;
            if (symptomsList.Count == 0) return new PredictFromSymptomsResult(null);
            string? predictedDiagnosis = GetPredictedDiagnosis(symptomsList);

            if (predictedDiagnosis != null)
            {
                var diagnosis = await dbContext.Diagnosis
                    .Where(d => d.Name == predictedDiagnosis)
                    .FirstOrDefaultAsync();

                if (diagnosis != null)
                {
                    return new PredictFromSymptomsResult(diagnosis.ToDiagnosisDto());
                }
            }

            return new PredictFromSymptomsResult(null);
        }

        private static string? GetPredictedDiagnosis(List<SymptomDTO> symptoms)
        {
            List<int> DiagnosisToBinaryEquivalentList = CreateListOfZeros();
            foreach (SymptomDTO symptom in symptoms)
            {
                int symptomIndexInList = int.Parse(symptom.Code);
                DiagnosisToBinaryEquivalentList[symptomIndexInList] = 1;
            }

            string? predictedDiagnosis = AiModule.GetDiagnosisBySymptoms(DiagnosisToBinaryEquivalentList);

            return predictedDiagnosis;
        }

        private static List<int> CreateListOfZeros()
        {
            // 132 is the number of symptoms supported by the current ai model
            int numberOfAiModelInputs = 132;
            var list = new List<int>();
            for (int i = 0; i < numberOfAiModelInputs; i++)
            {
                list.Add(0);
            }
            return list;
        }
    }
}