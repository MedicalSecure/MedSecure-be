﻿using Prescription.Application.DTOs;
using Prescription.Domain.Entities;
using Prescription.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Infrastructure.Database.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.Property(d => d.Code)
            .HasMaxLength(50);

            builder.Property(p => p.Id)
.HasConversion(Diagnosis => Diagnosis.Value,
                      dbId => DiagnosisId.Of(dbId));

            builder.Property(d => d.Name)
                .HasMaxLength(50).IsRequired();

            builder.Property(d => d.ShortDescription)
                .HasMaxLength(100);

            builder.Property(d => d.LongDescription)
                .HasMaxLength(250);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);
        }
    }
}