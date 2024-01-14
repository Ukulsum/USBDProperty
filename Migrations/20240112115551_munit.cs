using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class munit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "PropertyDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "PropertyDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Furnishing",
                table: "PropertyDetails",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "Facing",
                table: "PropertyDetails",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "ConstructionStatus",
                table: "PropertyDetails",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<bool>(
                name: "ISFeatured",
                table: "PropertyDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementID",
                table: "PropertyDetails",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_MeasurementID",
                table: "PropertyDetails",
                column: "MeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_MeasurementUnit_MeasurementID",
                table: "PropertyDetails",
                column: "MeasurementID",
                principalTable: "MeasurementUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_MeasurementUnit_MeasurementID",
                table: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetails_MeasurementID",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "ISFeatured",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "MeasurementID",
                table: "PropertyDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "PropertyDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Furnishing",
                table: "PropertyDetails",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Facing",
                table: "PropertyDetails",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ConstructionStatus",
                table: "PropertyDetails",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "PropertyDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
