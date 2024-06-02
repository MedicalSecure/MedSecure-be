using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixNullableEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Other",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Other");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "English",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "English");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Other",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Other");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "English",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "English");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
