using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMP280API.Migrations
{
    public partial class INit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ModuleDatas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Longitude = table.Column<double>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Temperature = table.Column<float>(nullable: false),
                    Pression = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ModuleGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleDatas", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ModuleDatas_Modules_ModuleGuid",
                        column: x => x.ModuleGuid,
                        principalTable: "Modules",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleDatas_ModuleGuid",
                table: "ModuleDatas",
                column: "ModuleGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleDatas");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
