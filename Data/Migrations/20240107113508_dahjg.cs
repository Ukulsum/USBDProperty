using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class dahjg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_PropertyFors_PropertyForId",
                table: "PropertyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_PropertyForId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "PropertyForId",
                table: "PropertyDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "PropertyDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransactionType",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PropertyForId",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_PropertyForId",
                table: "PropertyDetails",
                column: "PropertyForId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_PropertyFors_PropertyForId",
                table: "PropertyDetails",
                column: "PropertyForId",
                principalTable: "PropertyFors",
                principalColumn: "PropertyForId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
