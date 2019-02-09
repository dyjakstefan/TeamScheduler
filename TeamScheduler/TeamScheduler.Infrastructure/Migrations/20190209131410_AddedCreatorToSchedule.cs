using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class AddedCreatorToSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CreatorId",
                table: "Schedules",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_CreatorId",
                table: "Schedules",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_CreatorId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CreatorId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Schedules");
        }
    }
}
