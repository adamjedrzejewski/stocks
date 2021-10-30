using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Migrations
{
    public partial class addseriesnametotickerdatapointtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeriesName",
                table: "ticker_data_points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeriesName",
                table: "ticker_data_points");
        }
    }
}
