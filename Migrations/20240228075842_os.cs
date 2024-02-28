using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class os : Migration
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
                name: "PropertyFeaturedId",
                table: "PropertyDetails",
                type: "int",
                nullable: true,
                defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyDetails_PropertyFeaturedId",
            //    table: "PropertyDetails",
            //    column: "PropertyFeaturedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_PropertyFeatures_PropertyFeaturedId",
                table: "PropertyDetails",
                column: "PropertyFeaturedId",
                principalTable: "PropertyFeatures",
                principalColumn: "PropertyFeatureId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_PropertyFeatures_PropertyFeaturedId",
                table: "PropertyDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_PropertyDetails_PropertyFeaturedId",
            //    table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "PropertyFeaturedId",
                table: "PropertyDetails");

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
