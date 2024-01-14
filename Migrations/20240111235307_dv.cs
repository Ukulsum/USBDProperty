using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class dv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "DevelopersorAgent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "DevelopersorAgent",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
