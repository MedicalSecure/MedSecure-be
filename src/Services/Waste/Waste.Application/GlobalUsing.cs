﻿global using Microsoft.FeatureManagement;
global using BuildingBlocks.Behaviors;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Messaging.Events;
global using BuildingBlocks.Messaging.MassTransit;
global using BuildingBlocks.Pagination;
global using FluentValidation;
global using MassTransit;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Reflection;
global using Waste.Application.Data;
global using Waste.Application.Dtos;
global using Waste.Application.Exceptions;
global using Waste.Application.Extensions;
global using Waste.Application.Waste.Commands.CreateWaste;
global using Waste.Application.Room.EventHandlers.Domain;
global using Waste.Domain.Enums;
global using Waste.Domain.Events;
global using Waste.Domain.Models;
global using Waste.Domain.ValueObjects;