using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace watchdog.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchDogItems",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    FrequencyMinutes = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchDogItems", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchDogItems");
        }
    }
}
