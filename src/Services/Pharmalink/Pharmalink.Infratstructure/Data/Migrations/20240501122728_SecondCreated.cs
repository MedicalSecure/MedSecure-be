using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmalink.Infratstructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableStock",
                table: "Medications",
                type: "int",
                nullable: false,
                computedColumnSql: "[Stock] - [ReservedStock]");

            migrationBuilder.CreateTable(
                name: "Dosages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dosages");

            migrationBuilder.DropColumn(
                name: "AvailableStock",
                table: "Medications");
        }
    }
}
