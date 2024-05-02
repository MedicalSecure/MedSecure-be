﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Infrastructure.Data;

#nullable disable

namespace Registration.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Registration.Domain.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CIN")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<int>("CNAM")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Children")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("SINGLE");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Other");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Registration.Domain.Models.Register", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("PatientId1");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RegisterId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RegisterId2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RegisterId3")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.HasIndex("RegisterId1");

                    b.HasIndex("RegisterId2");

                    b.HasIndex("RegisterId3");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RiskFactors");
                });

            modelBuilder.Entity("Registration.Domain.Models.Register", b =>
                {
                    b.HasOne("Registration.Domain.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("PersonalMedicalHistory")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("Disease")
                        .HasForeignKey("RegisterId1");

                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("Allergy")
                        .HasForeignKey("RegisterId2");

                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("FamilyMedicalHistory")
                        .HasForeignKey("RegisterId3");

                    b.HasOne("Registration.Domain.Models.RiskFactor", null)
                        .WithMany("SubRiskfactory")
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registration.Domain.Models.Register", b =>
                {
                    b.Navigation("Allergy");

                    b.Navigation("Disease");

                    b.Navigation("FamilyMedicalHistory");

                    b.Navigation("PersonalMedicalHistory");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.Navigation("SubRiskfactory");
                });
#pragma warning restore 612, 618
        }
    }
}
