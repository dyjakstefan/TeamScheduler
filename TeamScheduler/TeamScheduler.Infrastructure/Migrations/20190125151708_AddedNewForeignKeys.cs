using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class AddedNewForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ScheduleId",
                table: "Tasks",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedules_ScheduleId",
                table: "Tasks",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_ScheduleId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ScheduleId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Tasks");
        }
    }
}
