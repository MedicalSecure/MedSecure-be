using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Infrastructure.Migrations.Data
{
    /// <inheritdoc />
    public partial class InitialM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CNAM = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Assurance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Other"),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    AddressIsRegisterations = table.Column<bool>(type: "bit", nullable: false),
                    SaveForNextTime = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActivityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "HIGH"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "TN"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    FamilyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "SINGLE"),
                    Children = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "None"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Resident"),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterIdForDisease = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterIdForAllergy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterIdForFamilyMedicalHistory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterIdForPersonalMedicalHistory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskFactors_Registers_RegisterIdForAllergy",
                        column: x => x.RegisterIdForAllergy,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskFactors_Registers_RegisterIdForDisease",
                        column: x => x.RegisterIdForDisease,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskFactors_Registers_RegisterIdForFamilyMedicalHistory",
                        column: x => x.RegisterIdForFamilyMedicalHistory,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskFactors_Registers_RegisterIdForPersonalMedicalHistory",
                        column: x => x.RegisterIdForPersonalMedicalHistory,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "English"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Other"),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubRiskFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskFactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRiskFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRiskFactors_RiskFactors_RiskFactorId",
                        column: x => x.RiskFactorId,
                        principalTable: "RiskFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_RegisterId",
                table: "Histories",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_PatientId",
                table: "Registers",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskFactors_RegisterIdForAllergy",
                table: "RiskFactors",
                column: "RegisterIdForAllergy");

            migrationBuilder.CreateIndex(
                name: "IX_RiskFactors_RegisterIdForDisease",
                table: "RiskFactors",
                column: "RegisterIdForDisease");

            migrationBuilder.CreateIndex(
                name: "IX_RiskFactors_RegisterIdForFamilyMedicalHistory",
                table: "RiskFactors",
                column: "RegisterIdForFamilyMedicalHistory");

            migrationBuilder.CreateIndex(
                name: "IX_RiskFactors_RegisterIdForPersonalMedicalHistory",
                table: "RiskFactors",
                column: "RegisterIdForPersonalMedicalHistory");

            migrationBuilder.CreateIndex(
                name: "IX_SubRiskFactors_RiskFactorId",
                table: "SubRiskFactors",
                column: "RiskFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_RegisterId",
                table: "Tests",
                column: "RegisterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "SubRiskFactors");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "RiskFactors");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
