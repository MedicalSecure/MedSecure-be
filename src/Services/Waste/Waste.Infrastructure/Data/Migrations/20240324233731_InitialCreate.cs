using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wastes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Black"),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DropOffLocation_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DropOffLocation_ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PickupLocation_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PickupLocation_ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wastes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wastes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WasteItems_Wastes_WasteId",
                        column: x => x.WasteId,
                        principalTable: "Wastes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WasteItems_ProductId",
                table: "WasteItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteItems_WasteId",
                table: "WasteItems",
                column: "WasteId");

            migrationBuilder.CreateIndex(
                name: "IX_Wastes_RoomId",
                table: "Wastes",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WasteItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Wastes");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
