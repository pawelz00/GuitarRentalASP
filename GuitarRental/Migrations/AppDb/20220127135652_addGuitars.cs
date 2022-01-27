using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarRental.Migrations.AppDb
{
    public partial class addGuitars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuitarStrings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarStrings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuitarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guitars",
                columns: table => new
                {
                    GuitarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    GuitarTypeId = table.Column<int>(type: "int", nullable: false),
                    GuitarStringsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.GuitarId);
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarStrings_GuitarStringsId",
                        column: x => x.GuitarStringsId,
                        principalTable: "GuitarStrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarTypes_GuitarTypeId",
                        column: x => x.GuitarTypeId,
                        principalTable: "GuitarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GuitarStrings",
                columns: new[] { "Id", "StringsName" },
                values: new object[,]
                {
                    { 1, "Nylonowe" },
                    { 2, "Stalowe" }
                });

            migrationBuilder.InsertData(
                table: "GuitarTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Klasyczna" },
                    { 2, "Elektryczna" },
                    { 3, "Akustyczna" }
                });

            migrationBuilder.InsertData(
                table: "Guitars",
                columns: new[] { "GuitarId", "GuitarStringsId", "GuitarTypeId", "Name", "ProductionYear" },
                values: new object[] { 3, 1, 1, "Yamaha c30m 4/4", 2021 });

            migrationBuilder.InsertData(
                table: "Guitars",
                columns: new[] { "GuitarId", "GuitarStringsId", "GuitarTypeId", "Name", "ProductionYear" },
                values: new object[] { 1, 2, 2, "Fender Stratocaster Black", 2000 });

            migrationBuilder.InsertData(
                table: "Guitars",
                columns: new[] { "GuitarId", "GuitarStringsId", "GuitarTypeId", "Name", "ProductionYear" },
                values: new object[] { 2, 2, 3, "Takamine GD10 NS", 2016 });

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_GuitarStringsId",
                table: "Guitars",
                column: "GuitarStringsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_GuitarTypeId",
                table: "Guitars",
                column: "GuitarTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitars");

            migrationBuilder.DropTable(
                name: "GuitarStrings");

            migrationBuilder.DropTable(
                name: "GuitarTypes");
        }
    }
}
