using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateSymptoms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Symptoms",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Symptoms",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Symptoms",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Symptoms");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Symptoms",
                newName: "Description");
        }
    }
}