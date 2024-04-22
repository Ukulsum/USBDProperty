using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
