global using Prescription.Domain.Entities;
global using System;
global using System.Collections.Generic;
global using Mapster;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Pagination;
global using Prescription.Application.DTOs;
global using Microsoft.EntityFrameworkCore;
global using Prescription.Domain.Enums;
global using Prescription.Application;

global using Prescription.Application.Features.Prescription.Commands.CreatePrescription;

global using Prescription.Application.Features.Prescription.Queries.GetPrescription;
global using Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterId;
global using Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterIdList;
global using Prescription.Application.Contracts;
global using Prescription.Application.Extensions;
global using Prescription.Domain.ValueObjects;

namespace Prescription.Application
{
    public class GlobalUsings
    {
    }
}