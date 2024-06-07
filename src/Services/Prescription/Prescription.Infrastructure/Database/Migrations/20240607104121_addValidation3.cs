using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addValidation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Validation_PrescriptionId",
                table: "Validation");

            migrationBuilder.CreateIndex(
                name: "IX_Validation_PrescriptionId",
                table: "Validation",
                column: "PrescriptionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Validation_PrescriptionId",
                table: "Validation");

            migrationBuilder.CreateIndex(
                name: "IX_Validation_PrescriptionId",
                table: "Validation",
                column: "PrescriptionId");
        }
    }
}
