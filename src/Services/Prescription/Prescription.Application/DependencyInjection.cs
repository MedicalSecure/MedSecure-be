using BuildingBlocks.Behaviors;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Prescription.Application.Features.Diagnosis;
using Prescription.Application.Hubs;
using Prescription.Application.Hubs.Abstractions;
using Prescription.Services.PredictBySymptomsService;
using System.Reflection;

namespace Prescription.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add MediatR for handling commands and queries
            services.AddMediatR(config =>
            {
                // Register handlers from the executing assembly
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                // Add behaviors for validation and logging
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            // Add feature management for managing feature flags
            services.AddFeatureManagement();

            // Add validators
            services.AddDiagnosisValidators();

            // Add message broker for async communication
            services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

            //inject configuration into the ai module
            AiModule.addAiModule(configuration);

            // Add Hubs
            services.AddTransient<IPrescriptionHub, PrescriptionHub>();


            // Return the modified service collection
            return services;
        }
    }
}