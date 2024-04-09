using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class configureDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Prescriptions_PrescriptionEntityId",
                table: "Diagnosis");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosis_PrescriptionEntityId",
                table: "Diagnosis");

            migrationBuilder.DropColumn(
                name: "PrescriptionEntityId",
                table: "Diagnosis");

            migrationBuilder.CreateTable(
                name: "DiagnosisPrescriptionEntity",
                columns: table => new
                {
                    DiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisPrescriptionEntity", x => new { x.DiagnosisId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_DiagnosisPrescriptionEntity_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisPrescriptionEntity_Prescriptions_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisPrescriptionEntity_PrescriptionsId",
                table: "DiagnosisPrescriptionEntity",
                column: "PrescriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisPrescriptionEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "PrescriptionEntityId",
                table: "Diagnosis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_PrescriptionEntityId",
                table: "Diagnosis",
                column: "PrescriptionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Prescriptions_PrescriptionEntityId",
                table: "Diagnosis",
                column: "PrescriptionEntityId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }
    }
}
