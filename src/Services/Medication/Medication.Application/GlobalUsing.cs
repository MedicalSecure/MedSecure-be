﻿global using BuildingBlocks.Behaviors;
global using BuildingBlocks.Messaging.MassTransit;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.FeatureManagement;
global using System.Reflection;
global using Microsoft.EntityFrameworkCore;
global using BuildingBlocks.Exceptions;
global using Medication.Domain.Models;
global using Medication.Application.Dtos;
global using BuildingBlocks.CQRS;
global using FluentValidation;
global using Medication.Application.Data;
global using Medication.Domain.ValueObjects;
global using Medication.Application.Exceptions;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using Medication.Domain.Events;
global using BuildingBlocks.Pagination;
global using Medication.Application.Extensions;