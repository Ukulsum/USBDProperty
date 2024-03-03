using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class feature1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_PropertyDetails_PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures",
                column: "PropertyDetailsPropertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_PropertyDetails_PropertyDetailsPropertyInfoId",
                table: "PropertyFeatures",
                column: "PropertyDetailsPropertyInfoId",
                principalTable: "PropertyDetails",
                principalColumn: "PropertyInfoId");
        }
    }
}
