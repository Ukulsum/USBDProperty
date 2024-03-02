using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
