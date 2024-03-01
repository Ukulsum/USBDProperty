using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class jds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_PropertyFeatures_PropertyFeaturedId",
                table: "PropertyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_PropertyFeaturedId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "PropertyFeaturedId",
                table: "PropertyDetails");

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
                name: "PropertyFeaturedId",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_PropertyFeaturedId",
                table: "PropertyDetails",
                column: "PropertyFeaturedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_PropertyFeatures_PropertyFeaturedId",
                table: "PropertyDetails",
                column: "PropertyFeaturedId",
                principalTable: "PropertyFeatures",
                principalColumn: "PropertyFeatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
