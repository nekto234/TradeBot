using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddNewColumnToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountByOrderPrice",
                table: "SteamItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountBySellPrice",
                table: "SteamItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountByOrderPrice",
                table: "SteamItems");

            migrationBuilder.DropColumn(
                name: "CountBySellPrice",
                table: "SteamItems");
        }
    }
}
