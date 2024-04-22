using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class das : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interested",
                table: "ClientInterest");

            migrationBuilder.AddColumn<int>(
                name: "Interested",
                table: "ClientContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interested",
                table: "ClientContacts");

            migrationBuilder.AddColumn<int>(
                name: "Interested",
                table: "ClientInterest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
