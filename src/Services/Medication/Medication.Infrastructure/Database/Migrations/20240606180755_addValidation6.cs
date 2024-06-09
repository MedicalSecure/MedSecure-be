using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medication.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addValidation6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Validations_PrescriptionId",
                table: "Validations",
                column: "PrescriptionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Validations_PrescriptionId",
                table: "Validations");
        }
    }
}
