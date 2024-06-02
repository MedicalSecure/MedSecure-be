using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prescription.Application.Features.Prescription.Commands.CreatePrescription;

using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;
using Prescription.Application.Features.Prescription.Queries.GetPrescription;

namespace Prescription.Application.Features.Prescription
{
    public static class InjectValidators
    {
        public static IServiceCollection AddPrescriptionValidators(this IServiceCollection services)
        {
            //validators
            services.AddScoped<IValidator<UpdatePrescriptionCommand>, UpdatePrescriptionCommandValidator>();
            services.AddScoped<IValidator<CreatePrescriptionCommand>, CreatePrescriptionCommandValidator>();
            services.AddScoped<IValidator<GetPrescriptionsQuery>, GetPrescriptionsQueryValidator>();

            return services;
        }
    }
}