using Microsoft.EntityFrameworkCore;
using BacPatient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Infrastructure.Database.Configurations
{
    //called from : ApplicationDbContext :
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public RegisterConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(r => r.Patient)
                .WithOne(p => p.Register)
                .HasForeignKey<Register>(r => r.PatientId);

            builder.Property(p => p.PatientId)
            .IsRequired();

            builder.HasMany(r => r.FamilyMedicalHistory)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterRiskFactor",
                    j => j.HasOne<RiskFactor>().WithMany().HasForeignKey("RiskFactorId"),
                    j => j.HasOne<Register>().WithMany().HasForeignKey("RegisterId")
            );

            builder.HasMany(r => r.PersonalMedicalHistory)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterRiskFactor",
                    j => j.HasOne<RiskFactor>().WithMany().HasForeignKey("RiskFactorId"),
                    j => j.HasOne<Register>().WithMany().HasForeignKey("RegisterId")
            );

            builder.HasMany(r => r.Diseases)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterRiskFactor",
                    j => j.HasOne<RiskFactor>().WithMany().HasForeignKey("RiskFactorId"),
                    j => j.HasOne<Register>().WithMany().HasForeignKey("RegisterId")
            );

            builder.HasMany(r => r.Allergies)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RegisterRiskFactor",
                    j => j.HasOne<RiskFactor>().WithMany().HasForeignKey("RiskFactorId"),
                    j => j.HasOne<Register>().WithMany().HasForeignKey("RegisterId")
                );

            builder.HasMany(r => r.History)
                .WithOne()
                .HasForeignKey(h => h.RegisterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Test)
                .WithOne()
                .HasForeignKey(t => t.RegisterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.LastModifiedBy)
                .HasMaxLength(128);

            builder.Property(d => d.CreatedBy)
                .HasMaxLength(128);

            /*         builder.HasMany(p => p.Prescriptions)
                         .WithOne()
                         .HasForeignKey(pr => pr.RegisterId)
                         .OnDelete(DeleteBehavior.Cascade);*/
        }

        /*        public void Configure(EntityTypeBuilder<Register> builder)
                {
                    builder.HasKey(p => p.Id);

                    builder.HasOne(r => r.Patient)
                        .WithOne(p => p.Register)
                        .HasForeignKey<Register>(r => r.PatientId);

                    builder.Property(p => p.PatientId)
                        .IsRequired();

                    builder.HasMany(p => p.FamilyMedicalHistory)
                        .WithOne()
                        .HasForeignKey(rf => rf.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(p => p.PersonalMedicalHistory)
                        .WithOne()
                        .HasForeignKey(rf => rf.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(p => p.Diseases)
                        .WithOne()
                        .HasForeignKey(rf => rf.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(p => p.Allergies)
                        .WithOne()
                        .HasForeignKey(rf => rf.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(r => r.History)
                        .WithOne()
                        .HasForeignKey(h => h.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(r => r.Test)
                        .WithOne()
                        .HasForeignKey(t => t.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);

                    builder.HasMany(p => p.Prescriptions)
                        .WithOne()
                        .HasForeignKey(pr => pr.RegisterId)
                        .OnDelete(DeleteBehavior.Cascade);
                }*/
    }
}