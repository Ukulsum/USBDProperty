using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class pd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlatSize1",
                table: "PropertyDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LandPrice1",
                table: "PropertyDetails",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlatSize1",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "LandPrice1",
                table: "PropertyDetails");
        }
    }
}
