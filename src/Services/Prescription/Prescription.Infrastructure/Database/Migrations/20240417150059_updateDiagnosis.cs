using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Diagnosis",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Diagnosis",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Diagnosis",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Diagnosis");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Diagnosis");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Diagnosis",
                newName: "Description");
        }
    }
}