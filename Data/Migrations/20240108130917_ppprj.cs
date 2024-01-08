using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class ppprj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_PropertyOwnerInfos_OwnerId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_SocialIcons_IconId",
                table: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "PropertyFors");

            migrationBuilder.DropTable(
                name: "PropertyOwnerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_IconId",
                table: "PropertyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_OwnerId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "PropertyDetails");

            migrationBuilder.RenameColumn(
                name: "IconId",
                table: "PropertyDetails",
                newName: "propertyFor");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsInfoId",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyCondition",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DevelopersorAgent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PostedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DevelopersorAgentID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopersorAgent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DevelopersorAgent_DevelopersorAgent_DevelopersorAgentID",
                        column: x => x.DevelopersorAgentID,
                        principalTable: "DevelopersorAgent",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationMap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsInfo_DevelopersorAgent_AgentID",
                        column: x => x.AgentID,
                        principalTable: "DevelopersorAgent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImageGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImageGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImageGallery_ProjectsInfo_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_ProjectsInfoId",
                table: "PropertyDetails",
                column: "ProjectsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopersorAgent_DevelopersorAgentID",
                table: "DevelopersorAgent",
                column: "DevelopersorAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImageGallery_ProjectID",
                table: "ProjectImageGallery",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsInfo_AgentID",
                table: "ProjectsInfo",
                column: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectsInfoId",
                table: "PropertyDetails",
                column: "ProjectsInfoId",
                principalTable: "ProjectsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_ProjectsInfo_ProjectsInfoId",
                table: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "ProjectImageGallery");

            migrationBuilder.DropTable(
                name: "ProjectsInfo");

            migrationBuilder.DropTable(
                name: "DevelopersorAgent");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_ProjectsInfoId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "ProjectsInfoId",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "PropertyCondition",
                table: "PropertyDetails");

            migrationBuilder.RenameColumn(
                name: "propertyFor",
                table: "PropertyDetails",
                newName: "IconId");

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "PropertyDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PropertyFors",
                columns: table => new
                {
                    PropertyForId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropeFor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFors", x => x.PropertyForId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwnerInfos",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PostedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwnerInfos", x => x.OwnerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_IconId",
                table: "PropertyDetails",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_OwnerId",
                table: "PropertyDetails",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_PropertyOwnerInfos_OwnerId",
                table: "PropertyDetails",
                column: "OwnerId",
                principalTable: "PropertyOwnerInfos",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_SocialIcons_IconId",
                table: "PropertyDetails",
                column: "IconId",
                principalTable: "SocialIcons",
                principalColumn: "IconId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
