using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class mem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PropertyName",
            //    table: "PropertyDetails");

            migrationBuilder.AddColumn<int>(
                name: "Membership",
                table: "DevelopersorAgent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyForId",
                table: "ClientInterest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Membership",
                table: "DevelopersorAgent");

            //migrationBuilder.AddColumn<string>(
            //    name: "PropertyName",
            //    table: "PropertyDetails",
            //    type: "nvarchar(150)",
            //    maxLength: 150,
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyForId",
                table: "ClientInterest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
