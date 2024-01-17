using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ClientContacts");

            migrationBuilder.CreateTable(
                name: "ClientInterest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    PropertyForId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyFor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInterest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientInterest_ClientContacts_ClientID",
                        column: x => x.ClientID,
                        principalTable: "ClientContacts",
                        principalColumn: "ClientContactId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientInterest_PropertyDetails_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "PropertyDetails",
                        principalColumn: "PropertyInfoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientInterest_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "PropertyTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientInterest_ClientID",
                table: "ClientInterest",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInterest_PropertyID",
                table: "ClientInterest",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInterest_PropertyTypeId",
                table: "ClientInterest",
                column: "PropertyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientInterest");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ClientContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
