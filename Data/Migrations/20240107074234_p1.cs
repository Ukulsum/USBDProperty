using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Data.Migrations
{
    public partial class p1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContacts_PropertyFors_PropertyForId1",
                table: "ClientContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientContacts_PropertyTypes_PropertyTypeId",
                table: "ClientContacts");

            migrationBuilder.DropIndex(
                name: "IX_ClientContacts_PropertyForId1",
                table: "ClientContacts");

            migrationBuilder.DropIndex(
                name: "IX_ClientContacts_PropertyTypeId",
                table: "ClientContacts");

            migrationBuilder.DropColumn(
                name: "PropertyForId",
                table: "ClientContacts");

            migrationBuilder.DropColumn(
                name: "PropertyForId1",
                table: "ClientContacts");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                table: "ClientContacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyForId",
                table: "ClientContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PropertyForId1",
                table: "ClientContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                table: "ClientContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_PropertyForId1",
                table: "ClientContacts",
                column: "PropertyForId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_PropertyTypeId",
                table: "ClientContacts",
                column: "PropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContacts_PropertyFors_PropertyForId1",
                table: "ClientContacts",
                column: "PropertyForId1",
                principalTable: "PropertyFors",
                principalColumn: "PropertyForId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContacts_PropertyTypes_PropertyTypeId",
                table: "ClientContacts",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "PropertyTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
