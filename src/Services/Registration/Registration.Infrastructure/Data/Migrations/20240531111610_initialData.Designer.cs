﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Infrastructure.Data;

#nullable disable

namespace Registration.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240531111610_initialData")]
    partial class initialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegisterAllergy", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RegisterId", "RiskFactorId");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RegisterAllergy");
                });

            modelBuilder.Entity("RegisterDisease", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RegisterId", "RiskFactorId");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RegisterDisease");
                });

            modelBuilder.Entity("RegisterFamilyMedicalHistory", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RegisterId", "RiskFactorId");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RegisterFamilyMedicalHistory");
                });

            modelBuilder.Entity("RegisterPersonalMedicalHistory", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RegisterId", "RiskFactorId");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RegisterPersonalMedicalHistory");
                });

            modelBuilder.Entity("Registration.Domain.Models.History", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Resident");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Registration.Domain.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActivityStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("HIGH");

                    b.Property<string>("Address1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("AddressIsRegisterations")
                        .HasColumnType("bit");

                    b.Property<string>("Assurance")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("CNAM")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Children")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("Country")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("TN");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("RegularExpression", "^[\\w.-]+@([\\w-]+\\.)+[\\w-]{2,4}$");

                    b.Property<string>("FamilyStatus")
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

                    b.Property<int?>("Height")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("SaveForNextTime")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ZipCode")
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Icon")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("RiskFactorParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("RiskFactorParentId");

                    b.ToTable("RiskFactors");
                });

            modelBuilder.Entity("Registration.Domain.Models.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Language")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("English");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Other");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("RegisterAllergy", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.RiskFactor", null)
                        .WithMany()
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterDisease", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.RiskFactor", null)
                        .WithMany()
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterFamilyMedicalHistory", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.RiskFactor", null)
                        .WithMany()
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterPersonalMedicalHistory", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registration.Domain.Models.RiskFactor", null)
                        .WithMany()
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registration.Domain.Models.History", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("History")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registration.Domain.Models.Register", b =>
                {
                    b.HasOne("Registration.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.HasOne("Registration.Domain.Models.RiskFactor", "RiskFactorParent")
                        .WithMany("SubRiskFactors")
                        .HasForeignKey("RiskFactorParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("RiskFactorParent");
                });

            modelBuilder.Entity("Registration.Domain.Models.Test", b =>
                {
                    b.HasOne("Registration.Domain.Models.Register", null)
                        .WithMany("Tests")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registration.Domain.Models.Register", b =>
                {
                    b.Navigation("History");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Registration.Domain.Models.RiskFactor", b =>
                {
                    b.Navigation("SubRiskFactors");
                });
#pragma warning restore 612, 618
        }
    }
}