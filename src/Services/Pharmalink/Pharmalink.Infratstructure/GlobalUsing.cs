﻿global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore;
global using Pharmalink.Domain.ValueObjects;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Pharmalink.Infrastructure.Data.Extensions;
global using Pharmalink.Domain.Models;
global using Pharmalink.Infratstructure.Data.Exceptions;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Pharmalink.Domain.Abstractions;
global using MediatR;
global using Pharmalink.Application.Data;
global using System.Reflection;
global using Microsoft.Extensions.Configuration;
global using Pharmalink.Infratstructure.Data;
global using Pharmalink.Infratstructure.Data.Interceptors;