using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "FlatSize",
            //    table: "PropertyDetails",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<float>(
            //    name: "LandPrice",
            //    table: "PropertyDetails",
            //    type: "real",
            //    nullable: true);
            //migrationBuilder.AddColumn<string>(
            //   name: "ImagePath",
            //   table: "PropertyDetails",
            //   type: "nvarchar(max)",
            //   nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FlatSize",
            //    table: "PropertyDetails");

            //migrationBuilder.DropColumn(
            //    name: "LandPrice",
            //    table: "PropertyDetails");
            //migrationBuilder.DropColumn(
            //   name: "ImagePath",
            //   table: "PropertyDetails");

        }
    }
}
