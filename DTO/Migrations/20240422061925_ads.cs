using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class ads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableFlatSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    AvailableFSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    PropertyDetailsPropertyInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableFlatSizes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AvailableFlatSizes_MeasurementUnit_UnitID",
                        column: x => x.UnitID,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableFlatSizes_PropertyDetails_PropertyDetailsPropertyInfoId",
                        column: x => x.PropertyDetailsPropertyInfoId,
                        principalTable: "PropertyDetails",
                        principalColumn: "PropertyInfoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableFlatSizes_PropertyDetailsPropertyInfoId",
                table: "AvailableFlatSizes",
                column: "PropertyDetailsPropertyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableFlatSizes_UnitID",
                table: "AvailableFlatSizes",
                column: "UnitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableFlatSizes");
        }
    }
}
