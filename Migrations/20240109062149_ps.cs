using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class ps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectsInfoId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "PropertyDetails");

            migrationBuilder.RenameColumn(
                name: "ProjectsInfoId",
                table: "PropertyDetails",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDetails_ProjectsInfoId",
                table: "PropertyDetails",
                newName: "IX_PropertyDetails_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectId",
                table: "PropertyDetails",
                column: "ProjectId",
                principalTable: "ProjectsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectId",
                table: "PropertyDetails");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "PropertyDetails",
                newName: "ProjectsInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDetails_ProjectId",
                table: "PropertyDetails",
                newName: "IX_PropertyDetails_ProjectsInfoId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectsInfoId",
                table: "PropertyDetails",
                column: "ProjectsInfoId",
                principalTable: "ProjectsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
