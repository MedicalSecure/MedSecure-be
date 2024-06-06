using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medication.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class addValidation5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posology_PosologyId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispense_Posology_PosologyId",
                table: "Dispense");

            migrationBuilder.DropForeignKey(
                name: "FK_Posology_Drugs_DrugId",
                table: "Posology");

            migrationBuilder.DropForeignKey(
                name: "FK_Posology_Validations_ValidationId",
                table: "Posology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posology",
                table: "Posology");

            migrationBuilder.RenameTable(
                name: "Posology",
                newName: "Posologies");

            migrationBuilder.RenameIndex(
                name: "IX_Posology_ValidationId",
                table: "Posologies",
                newName: "IX_Posologies_ValidationId");

            migrationBuilder.RenameIndex(
                name: "IX_Posology_DrugId",
                table: "Posologies",
                newName: "IX_Posologies_DrugId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posologies",
                table: "Posologies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posologies_PosologyId",
                table: "Comment",
                column: "PosologyId",
                principalTable: "Posologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispense_Posologies_PosologyId",
                table: "Dispense",
                column: "PosologyId",
                principalTable: "Posologies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posologies_Drugs_DrugId",
                table: "Posologies",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posologies_Validations_ValidationId",
                table: "Posologies",
                column: "ValidationId",
                principalTable: "Validations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posologies_PosologyId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispense_Posologies_PosologyId",
                table: "Dispense");

            migrationBuilder.DropForeignKey(
                name: "FK_Posologies_Drugs_DrugId",
                table: "Posologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Posologies_Validations_ValidationId",
                table: "Posologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posologies",
                table: "Posologies");

            migrationBuilder.RenameTable(
                name: "Posologies",
                newName: "Posology");

            migrationBuilder.RenameIndex(
                name: "IX_Posologies_ValidationId",
                table: "Posology",
                newName: "IX_Posology_ValidationId");

            migrationBuilder.RenameIndex(
                name: "IX_Posologies_DrugId",
                table: "Posology",
                newName: "IX_Posology_DrugId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posology",
                table: "Posology",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posology_PosologyId",
                table: "Comment",
                column: "PosologyId",
                principalTable: "Posology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispense_Posology_PosologyId",
                table: "Dispense",
                column: "PosologyId",
                principalTable: "Posology",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posology_Drugs_DrugId",
                table: "Posology",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posology_Validations_ValidationId",
                table: "Posology",
                column: "ValidationId",
                principalTable: "Validations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
