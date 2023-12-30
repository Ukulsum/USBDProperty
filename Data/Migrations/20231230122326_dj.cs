using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class dj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyFor",
                table: "PropertyDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyFor",
                table: "PropertyDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
