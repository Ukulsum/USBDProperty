using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class prj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "ProjectsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsInfo_AreaID",
                table: "ProjectsInfo",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsInfo_Areas_AreaID",
                table: "ProjectsInfo",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsInfo_Areas_AreaID",
                table: "ProjectsInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsInfo_AreaID",
                table: "ProjectsInfo");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "ProjectsInfo");
        }
    }
}
