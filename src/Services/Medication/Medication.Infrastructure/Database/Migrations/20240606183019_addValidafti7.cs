using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medication.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addValidafti7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispense_Posologies_PosologyId",
                table: "Dispense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispense",
                table: "Dispense");

            migrationBuilder.RenameTable(
                name: "Dispense",
                newName: "Dispenses");

            migrationBuilder.RenameIndex(
                name: "IX_Dispense_PosologyId",
                table: "Dispenses",
                newName: "IX_Dispenses_PosologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispenses",
                table: "Dispenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenses_Posologies_PosologyId",
                table: "Dispenses",
                column: "PosologyId",
                principalTable: "Posologies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispenses_Posologies_PosologyId",
                table: "Dispenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispenses",
                table: "Dispenses");

            migrationBuilder.RenameTable(
                name: "Dispenses",
                newName: "Dispense");

            migrationBuilder.RenameIndex(
                name: "IX_Dispenses_PosologyId",
                table: "Dispense",
                newName: "IX_Dispense_PosologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispense",
                table: "Dispense",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispense_Posologies_PosologyId",
                table: "Dispense",
                column: "PosologyId",
                principalTable: "Posologies",
                principalColumn: "Id");
        }
    }
}
