using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Location",
               table: "PropertyDetails",
               type: "nvarchar(150)",
               maxLength: 150,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(100)",
               oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
