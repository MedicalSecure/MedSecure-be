global using Carter;
global using HealthChecks.UI.Client;
global using Mapster;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Messaging.MassTransit;
global using BuildingBlocks.Pagination;

global using Visit.API;
global using Visit.Application;
global using Visit.Application.Data;
global using Visit.Application.Visits.Commands.CreateVisit;
global using Visit.Application.Visits.Commands.UpdateVisit;
global using Visit.Application.Visits.Commands.DeleteVist;
global using Visit.Application.Visits.Queries.GetVisitDetail;
global using Visit.Application.Visits.Queries.GetVisitList;

global using Visit.Application.Patients.Commands.CreatePatient;
global using Visit.Application.Patients.Commands.UpdatePatient;
global using Visit.Application.Patients.Queries.GetPatientByNameQuery;
global using Visit.Application.Patients.Queries.GetPatients;

global using Visit.Application.Dtos;
global using Visit.Infrastructure;
global using Visit.Infrastructure.Data.Extensions;
