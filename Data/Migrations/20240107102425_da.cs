using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class da : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_TransactionTypes_TransactionTypeId",
                table: "PropertyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_TransactionTypeId",
                table: "PropertyDetails");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "PropertyDetails",
                newName: "TransactionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "PropertyDetails",
                newName: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_TransactionTypeId",
                table: "PropertyDetails",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_TransactionTypes_TransactionTypeId",
                table: "PropertyDetails",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "TransactionTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
