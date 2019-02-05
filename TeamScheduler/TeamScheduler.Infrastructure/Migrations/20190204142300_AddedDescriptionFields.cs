using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamScheduler.Infrastructure.Migrations
{
    public partial class AddedDescriptionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Schedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Schedules");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "WorkUnits",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Schedules",
                nullable: false,
                defaultValue: false);
        }
    }
}
