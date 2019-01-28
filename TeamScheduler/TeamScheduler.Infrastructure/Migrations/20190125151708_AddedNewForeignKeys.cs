using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class AddedNewForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "WorkUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ScheduleId",
                table: "WorkUnits",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Schedules_ScheduleId",
                table: "WorkUnits",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Schedules_ScheduleId",
                table: "WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ScheduleId",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "WorkUnits");
        }
    }
}
