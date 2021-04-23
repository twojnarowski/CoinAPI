using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinAPI.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temp",
                table: "Currencies",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Currencies",
                newName: "temp");
        }
    }
}
