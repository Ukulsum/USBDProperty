using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class pfor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyForId",
                table: "PropertyDetails",
                type: "int",
                nullable: true,
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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
