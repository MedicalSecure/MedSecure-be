using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addReg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "SaveForNextTime",
                table: "Patients",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Other",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Other");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "SINGLE",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "SINGLE");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "TN",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TN");

            migrationBuilder.AlterColumn<string>(
                name: "Children",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "None",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "CNAM",
                table: "Patients",
                type: "int",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Assurance",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "AddressIsRegisterations",
                table: "Patients",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "HIGH",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "HIGH");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Resident",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Resident");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Registers");

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
                name: "ZipCode",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SaveForNextTime",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Other",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Other");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "SINGLE",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "SINGLE");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TN",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "TN");

            migrationBuilder.AlterColumn<string>(
                name: "Children",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "None");

            migrationBuilder.AlterColumn<int>(
                name: "CNAM",
                table: "Patients",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Assurance",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AddressIsRegisterations",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityStatus",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "HIGH",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "HIGH");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Resident",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Resident");
        }
    }
}
