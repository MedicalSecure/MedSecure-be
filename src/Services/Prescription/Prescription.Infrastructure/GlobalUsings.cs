global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Prescription.Domain.Entities.Prescription;
global using Prescription.Domain.Entities;
global using Prescription.Infrastructure.Database;
global using Prescription.Domain.Abstractions;
global using Prescription.Infrastructure.Database.Interceptors;

global using MediatR;

namespace Prescription.Infrastructure
{
    internal class GlobalUsing
    {
    }
}