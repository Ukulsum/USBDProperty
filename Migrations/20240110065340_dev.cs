using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class dev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DevelopersorAgent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "DevelopersorAgent",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DevelopersorAgent_AreaID",
                table: "DevelopersorAgent",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopersorAgent_Areas_AreaID",
                table: "DevelopersorAgent",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopersorAgent_Areas_AreaID",
                table: "DevelopersorAgent");

            migrationBuilder.DropIndex(
                name: "IX_DevelopersorAgent_AreaID",
                table: "DevelopersorAgent");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DevelopersorAgent");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "DevelopersorAgent");
        }
    }
}
