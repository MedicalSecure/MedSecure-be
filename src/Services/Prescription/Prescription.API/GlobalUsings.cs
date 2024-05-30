global using MediatR;
global using Prescription.Application.DTOs;
global using BuildingBlocks.Pagination;
global using Carter;
global using Mapster;
global using Microsoft.AspNetCore.Mvc;

global using Prescription.Application.Features.Prescription.Commands.CreatePrescription;

global using Prescription.Application.Features.Prescription.Queries.GetPrescription;
global using Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterId;
global using Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterIdList;

global using Prescription.Application.Exceptions;
global using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;
global using static Prescription.API.Endpoints.Prescription.Records;
global using Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus;
global using Prescription.Application;
global using Prescription.Infrastructure;

namespace Prescription.API
{
    public class GlobalUsings
    {
    }
}