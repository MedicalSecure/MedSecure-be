global using Visit.Application.Data;
global using Visit.Application.Dtos;
global using Visit.Application.Exceptions;
global using Visit.Application.Extensions;


global using Visit.Domain.Enums;
global using Visit.Domain.Events;
global using Visit.Domain.Models;
global using Visit.Domain.ValueObjects;

global using Microsoft.EntityFrameworkCore;
global using BuildingBlocks.Behaviors;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Messaging.Events;
global using BuildingBlocks.Messaging.MassTransit;
global using BuildingBlocks.Pagination;
global using FluentValidation;
global using Mapster;
global using MassTransit;
global using MediatR;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.FeatureManagement;
global using System.Reflection;
