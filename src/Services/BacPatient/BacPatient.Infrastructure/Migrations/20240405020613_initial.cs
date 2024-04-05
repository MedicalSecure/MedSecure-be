using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BacPatient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    activityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    riskFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    familyHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Beds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BacPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bed = table.Column<int>(type: "int", nullable: false),
                    servingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    served = table.Column<int>(type: "int", nullable: false),
                    toServe = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BacPatients_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BacPatients_UnitCare_UnitCareId",
                        column: x => x.UnitCareId,
                        principalTable: "UnitCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    forme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BPModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_BacPatients_BPModelId",
                        column: x => x.BPModelId,
                        principalTable: "BacPatients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posology",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantityBE = table.Column<int>(type: "int", nullable: false),
                    quantityAE = table.Column<int>(type: "int", nullable: false),
                    isPermanent = table.Column<bool>(type: "bit", nullable: false),
                    hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posology_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacPatients_PatientId",
                table: "BacPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BacPatients_RoomId",
                table: "BacPatients",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BacPatients_UnitCareId",
                table: "BacPatients",
                column: "UnitCareId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_BPModelId",
                table: "Medicine",
                column: "BPModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Posology_MedicineId",
                table: "Posology",
                column: "MedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posology");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "BacPatients");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "UnitCare");
        }
    }
}
