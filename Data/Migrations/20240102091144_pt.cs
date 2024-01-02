using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class pt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentPropertyTypeId",
                table: "PropertyTypes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentPropertyTypeId",
                table: "PropertyTypes");
        }
    }
}
