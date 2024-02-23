using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class Im : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
              name: "ImagePath",
              table: "Notices",
              type: "nvarchar(max)",
              nullable: true,
              defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
