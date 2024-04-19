﻿global using Microsoft.EntityFrameworkCore;
global using FluentValidation;
global using BuildingBlocks.Behaviors;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Messaging.Events;
global using BuildingBlocks.Messaging.MassTransit;
global using BuildingBlocks.Pagination;
global using Sensor.Application.Data;
global using Sensor.Application.Dtos;
global using Sensor.Application.Extensions;
global using Sensor.Domain.Enums;
global using Sensor.Domain.Events;
global using Sensor.Domain.Models;
global using Sensor.Domain.ValueObjects;
global using Mapster;
global using MassTransit;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.FeatureManagement;
global using System.Reflection;
