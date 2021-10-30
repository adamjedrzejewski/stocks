using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Migrations
{
    public partial class changetickerdatapointtableprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ticker_data_points",
                table: "ticker_data_points");

            migrationBuilder.AlterColumn<string>(
                name: "TickerName",
                table: "ticker_data_points",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ticker_data_points",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ticker_data_points",
                table: "ticker_data_points",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ticker_data_points",
                table: "ticker_data_points");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ticker_data_points");

            migrationBuilder.AlterColumn<string>(
                name: "TickerName",
                table: "ticker_data_points",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ticker_data_points",
                table: "ticker_data_points",
                columns: new[] { "Date", "TickerName" });
        }
    }
}
