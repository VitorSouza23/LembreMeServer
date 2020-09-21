using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LembreMeServer.Infra.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    Deadline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Number = table.Column<int>(nullable: false, defaultValue: 0),
                    Neighborhood = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    FederativeUnit = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    TaskId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TaskId",
                table: "Locations",
                column: "TaskId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
