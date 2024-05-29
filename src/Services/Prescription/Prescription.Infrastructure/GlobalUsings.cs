global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Prescription.Domain.Entities;

global using Prescription.Infrastructure.Database;
global using Prescription.Domain.Abstractions;
global using Prescription.Domain.ValueObjects;
global using Prescription.Domain.Enums;
global using Prescription.Domain.Entities.UnitCareRoot;

global using Prescription.Domain.Exceptions;
global using System.Collections.Generic;
global using MediatR;
global using Prescription.Infrastructure;

global using Mapster;
global using Prescription.Application.Contracts;
global using Prescription.Infrastructure.Database.Interceptors;

namespace Prescription.Infrastructure
{
    internal class GlobalUsing
    {
    }
}