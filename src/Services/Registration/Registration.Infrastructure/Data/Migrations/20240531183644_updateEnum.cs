using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActivityStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Light",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "HIGH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActivityStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "HIGH",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Light");
        }
    }
}
