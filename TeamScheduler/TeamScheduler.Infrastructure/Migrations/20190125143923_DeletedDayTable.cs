using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class DeletedDayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfWork_Days_DayId",
                table: "UnitsOfWork");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfWork_Members_MemberId",
                table: "UnitsOfWork");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfWork",
                table: "UnitsOfWork");

            migrationBuilder.DropIndex(
                name: "IX_UnitsOfWork_DayId",
                table: "UnitsOfWork");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "UnitsOfWork");

            migrationBuilder.RenameTable(
                name: "UnitsOfWork",
                newName: "WorkUnits");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsOfWork_MemberId",
                table: "WorkUnits",
                newName: "IX_WorkUnits_MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "WorkUnits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "WorkUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "WorkUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Members_MemberId",
                table: "WorkUnits",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Members_MemberId",
                table: "WorkUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WorkUnits");

            migrationBuilder.RenameTable(
                name: "WorkUnits",
                newName: "UnitsOfWork");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_MemberId",
                table: "UnitsOfWork",
                newName: "IX_UnitsOfWork_MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "UnitsOfWork",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "UnitsOfWork",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfWork",
                table: "UnitsOfWork",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfWork_DayId",
                table: "UnitsOfWork",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_ScheduleId",
                table: "Days",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfWork_Days_DayId",
                table: "UnitsOfWork",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfWork_Members_MemberId",
                table: "UnitsOfWork",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
