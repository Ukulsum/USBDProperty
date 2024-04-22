using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ImagePath",
            //    table: "Notices",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
            //migrationBuilder.DropColumn("Path", "Notices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ImagePath1",
            //    table: "Notices");
            //migrationBuilder.AddColumn<string>(
            //    name: "Path",
            //    table: "Notices",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
