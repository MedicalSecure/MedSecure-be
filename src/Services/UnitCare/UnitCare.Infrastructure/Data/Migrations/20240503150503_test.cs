using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EqStatus",
                table: "Equipments",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EqStatus",
                table: "Equipments");
        }
    }
}
