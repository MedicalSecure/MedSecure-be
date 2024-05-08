using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescription.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateDispense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityAM",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "QuantityBM",
                table: "Dispenses");

            migrationBuilder.AddColumn<int>(
                name: "AfterMeal_Quantity",
                table: "Dispenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AfterMeal_isPostValid",
                table: "Dispenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AfterMeal_isValid",
                table: "Dispenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BeforeMeal_Quantity",
                table: "Dispenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BeforeMeal_isPostValid",
                table: "Dispenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BeforeMeal_isValid",
                table: "Dispenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterMeal_Quantity",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "AfterMeal_isPostValid",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "AfterMeal_isValid",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "BeforeMeal_Quantity",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "BeforeMeal_isPostValid",
                table: "Dispenses");

            migrationBuilder.DropColumn(
                name: "BeforeMeal_isValid",
                table: "Dispenses");

            migrationBuilder.AddColumn<int>(
                name: "QuantityAM",
                table: "Dispenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityBM",
                table: "Dispenses",
                type: "int",
                nullable: true);
        }
    }
}
