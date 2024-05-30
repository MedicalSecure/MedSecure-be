using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis;
using Prescription.Application.Features.Diagnosis.Commands.DeleteDiagnosis;
using Prescription.Application.Features.Diagnosis.Commands.UpdateDiagnosis;
using Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Diagnosis
{
    public static class InjectValidators
    {
        public static IServiceCollection AddDiagnosisValidators(this IServiceCollection services)
        {
            //validators
            services.AddScoped<IValidator<DeleteDiagnosisCommand>, DeleteDiagnosisCommandValidator>();
            services.AddScoped<IValidator<UpdateDiagnosisCommand>, UpdateDiagnosisCommandValidator>();
            services.AddScoped<IValidator<CreateDiagnosisCommand>, CreateDiagnosisCommandValidator>();
            services.AddScoped<IValidator<GetDiagnosisQuery>, GetDiagnosisQueryValidator>();

            return services;
        }
    }
}
