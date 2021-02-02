using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace watchdog.Migrations
{
    public partial class LastCheckin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckin",
                table: "WatchDogItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCheckin",
                table: "WatchDogItems");
        }
    }
}
