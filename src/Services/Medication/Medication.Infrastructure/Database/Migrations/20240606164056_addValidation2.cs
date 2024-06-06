using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medication.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addValidation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_PosologySummary_PosologyId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "PosologySummary");

            migrationBuilder.CreateTable(
                name: "Posology",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posology_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dispense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    BeforeMeal = table.Column<int>(type: "int", nullable: true),
                    AfterMeal = table.Column<int>(type: "int", nullable: true),
                    PosologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispense_Posology_PosologyId",
                        column: x => x.PosologyId,
                        principalTable: "Posology",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispense_PosologyId",
                table: "Dispense",
                column: "PosologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Posology_DrugId",
                table: "Posology",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posology_PosologyId",
                table: "Comment",
                column: "PosologyId",
                principalTable: "Posology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posology_PosologyId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Dispense");

            migrationBuilder.DropTable(
                name: "Posology");

            migrationBuilder.CreateTable(
                name: "PosologySummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosologySummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosologySummary_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosologySummary_DrugId",
                table: "PosologySummary",
                column: "DrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_PosologySummary_PosologyId",
                table: "Comment",
                column: "PosologyId",
                principalTable: "PosologySummary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
