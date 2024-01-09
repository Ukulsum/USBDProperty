using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class pst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopersorAgent_DevelopersorAgent_DevelopersorAgentID",
                table: "DevelopersorAgent");

            migrationBuilder.DropTable(
                name: "MultipleImageUploads");

            migrationBuilder.DropIndex(
                name: "IX_DevelopersorAgent_DevelopersorAgentID",
                table: "DevelopersorAgent");

            migrationBuilder.DropColumn(
                name: "DevelopersorAgentID",
                table: "DevelopersorAgent");

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultiImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyImages_PropertyDetails_propertyInfoId",
                        column: x => x.propertyInfoId,
                        principalTable: "PropertyDetails",
                        principalColumn: "PropertyInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_propertyInfoId",
                table: "PropertyImages",
                column: "propertyInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.AddColumn<int>(
                name: "DevelopersorAgentID",
                table: "DevelopersorAgent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MultipleImageUploads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyInfoId = table.Column<int>(type: "int", nullable: false),
                    MultiImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleImageUploads", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MultipleImageUploads_PropertyDetails_propertyInfoId",
                        column: x => x.propertyInfoId,
                        principalTable: "PropertyDetails",
                        principalColumn: "PropertyInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopersorAgent_DevelopersorAgentID",
                table: "DevelopersorAgent",
                column: "DevelopersorAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleImageUploads_propertyInfoId",
                table: "MultipleImageUploads",
                column: "propertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopersorAgent_DevelopersorAgent_DevelopersorAgentID",
                table: "DevelopersorAgent",
                column: "DevelopersorAgentID",
                principalTable: "DevelopersorAgent",
                principalColumn: "ID");
        }
    }
}
