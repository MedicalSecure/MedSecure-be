using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medication.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addIndexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Drugs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "INDEX_DRUG",
                table: "Drugs",
                columns: new[] { "Name", "Dosage", "Form", "Code", "Unit", "Description" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "INDEX_DRUG",
                table: "Drugs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
