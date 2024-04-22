using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableFlatSizes_PropertyDetails_PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes");

            migrationBuilder.DropIndex(
                name: "IX_AvailableFlatSizes_PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes");

            migrationBuilder.DropColumn(
                name: "PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableFlatSizes_PropertyId",
                table: "AvailableFlatSizes",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableFlatSizes_PropertyDetails_PropertyId",
                table: "AvailableFlatSizes",
                column: "PropertyId",
                principalTable: "PropertyDetails",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableFlatSizes_PropertyDetails_PropertyId",
                table: "AvailableFlatSizes");

            migrationBuilder.DropIndex(
                name: "IX_AvailableFlatSizes_PropertyId",
                table: "AvailableFlatSizes");

            migrationBuilder.AddColumn<int>(
                name: "PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableFlatSizes_PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes",
                column: "PropertyDetailsPropertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableFlatSizes_PropertyDetails_PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes",
                column: "PropertyDetailsPropertyInfoId",
                principalTable: "PropertyDetails",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
