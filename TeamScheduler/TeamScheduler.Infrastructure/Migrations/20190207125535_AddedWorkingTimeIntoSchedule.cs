using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class AddedWorkingTimeIntoSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndOfWorkingTime",
                table: "Schedules",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartOfWorkingTime",
                table: "Schedules",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndOfWorkingTime",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StartOfWorkingTime",
                table: "Schedules");
        }
    }
}
