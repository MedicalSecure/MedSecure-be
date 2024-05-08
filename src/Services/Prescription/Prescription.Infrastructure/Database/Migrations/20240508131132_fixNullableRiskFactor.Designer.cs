﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prescription.Infrastructure.Database;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508131132_fixNullableRiskFactor")]
    partial class fixNullableRiskFactor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiagnosisPrescription", b =>
                {
                    b.Property<Guid>("DiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrescriptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DiagnosisId", "PrescriptionsId");

                    b.HasIndex("PrescriptionsId");

                    b.ToTable("DiagnosisPrescription");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.Diagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlertStock")
                        .HasColumnType("int");

                    b.Property<int>("AvrgStock")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("MinStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ReservedStock")
                        .HasColumnType("int");

                    b.Property<int>("SafetyStock")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("PosologyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PosologyId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Dispense", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PosologyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PosologyId");

                    b.ToTable("Dispenses");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Posology", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPermanent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("MedicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Posology");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UnitCareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.History", b =>
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
                        .HasDefaultValue("Registered");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ActivityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Address2")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("AddressIsRegisterations")
                        .HasColumnType("bit");

                    b.Property<string>("Assurance")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CIN")
                        .HasColumnType("int");

                    b.Property<int?>("CNAM")
                        .HasColumnType("int");

                    b.Property<int?>("Children")
                        .HasColumnType("int");

                    b.Property<int?>("Country")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("FamilyStatus")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("SaveForNextTime")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Register", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Register");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.RiskFactor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsSelected")
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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("RiskFactorParentId");

                    b.ToTable("RiskFactor");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
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
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("ClinicTest");

                    b.HasKey("Id");

                    b.HasIndex("RegisterId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.Symptom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EqStatus")
                        .HasMaxLength(500)
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Personnel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UnitCareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UnitCareId");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Room", b =>
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

                    b.Property<decimal>("RoomNumber")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UnitCareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UnitCareId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.UnitCare", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitCare");
                });

            modelBuilder.Entity("PrescriptionSymptom", b =>
                {
                    b.Property<Guid>("PrescriptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SymptomsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PrescriptionsId", "SymptomsId");

                    b.HasIndex("SymptomsId");

                    b.ToTable("PrescriptionSymptom");
                });

            modelBuilder.Entity("RegisterRiskFactor", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RiskFactorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RegisterId", "RiskFactorId");

                    b.HasIndex("RiskFactorId");

                    b.ToTable("RegisterRiskFactor");
                });

            modelBuilder.Entity("DiagnosisPrescription", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.Diagnosis", null)
                        .WithMany()
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prescription.Domain.Entities.PrescriptionRoot.Prescription", null)
                        .WithMany()
                        .HasForeignKey("PrescriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Comment", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.PrescriptionRoot.Posology", "posology")
                        .WithMany("Comments")
                        .HasForeignKey("PosologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("posology");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Dispense", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.PrescriptionRoot.Posology", "Posology")
                        .WithMany("Dispenses")
                        .HasForeignKey("PosologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Prescription.Domain.ValueObjects.Dose", "AfterMeal", b1 =>
                        {
                            b1.Property<Guid>("DispenseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.Property<bool>("isPostValid")
                                .HasColumnType("bit");

                            b1.Property<bool>("isValid")
                                .HasColumnType("bit");

                            b1.HasKey("DispenseId");

                            b1.ToTable("Dispenses");

                            b1.WithOwner()
                                .HasForeignKey("DispenseId");
                        });

                    b.OwnsOne("Prescription.Domain.ValueObjects.Dose", "BeforeMeal", b1 =>
                        {
                            b1.Property<Guid>("DispenseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.Property<bool>("isPostValid")
                                .HasColumnType("bit");

                            b1.Property<bool>("isValid")
                                .HasColumnType("bit");

                            b1.HasKey("DispenseId");

                            b1.ToTable("Dispenses");

                            b1.WithOwner()
                                .HasForeignKey("DispenseId");
                        });

                    b.Navigation("AfterMeal")
                        .IsRequired();

                    b.Navigation("BeforeMeal")
                        .IsRequired();

                    b.Navigation("Posology");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Posology", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prescription.Domain.Entities.PrescriptionRoot.Prescription", "Prescription")
                        .WithMany("Posology")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Prescription", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.Register", "Register")
                        .WithMany("Prescriptions")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.History", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.Register", null)
                        .WithMany("History")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Register", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.Patient", "Patient")
                        .WithOne("Register")
                        .HasForeignKey("Prescription.Domain.Entities.RegisterRoot.Register", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.RiskFactor", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.RiskFactor", "RiskFactorParent")
                        .WithMany("SubRiskFactor")
                        .HasForeignKey("RiskFactorParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("RiskFactorParent");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Test", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.Register", null)
                        .WithMany("Test")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Equipment", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.UnitCareRoot.Room", null)
                        .WithMany("Equipments")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Personnel", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.UnitCareRoot.UnitCare", null)
                        .WithMany("Personnels")
                        .HasForeignKey("UnitCareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Room", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.UnitCareRoot.UnitCare", null)
                        .WithMany("Rooms")
                        .HasForeignKey("UnitCareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrescriptionSymptom", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.PrescriptionRoot.Prescription", null)
                        .WithMany()
                        .HasForeignKey("PrescriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prescription.Domain.Entities.Symptom", null)
                        .WithMany()
                        .HasForeignKey("SymptomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterRiskFactor", b =>
                {
                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.Register", null)
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prescription.Domain.Entities.RegisterRoot.RiskFactor", null)
                        .WithMany()
                        .HasForeignKey("RiskFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Posology", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Dispenses");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.PrescriptionRoot.Prescription", b =>
                {
                    b.Navigation("Posology");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Patient", b =>
                {
                    b.Navigation("Register");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.Register", b =>
                {
                    b.Navigation("History");

                    b.Navigation("Prescriptions");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.RegisterRoot.RiskFactor", b =>
                {
                    b.Navigation("SubRiskFactor");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.Room", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("Prescription.Domain.Entities.UnitCareRoot.UnitCare", b =>
                {
                    b.Navigation("Personnels");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
