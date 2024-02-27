using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class sdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyInfoId",
                table: "PropertyFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_PropertyInfoId",
                table: "PropertyFeatures",
                column: "PropertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_PropertyDetails_PropertyInfoId",
                table: "PropertyFeatures",
                column: "PropertyInfoId",
                principalTable: "PropertyDetails",
                principalColumn: "PropertyInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_PropertyDetails_PropertyInfoId",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_PropertyInfoId",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "PropertyInfoId",
                table: "PropertyFeatures");
        }
    }
}
