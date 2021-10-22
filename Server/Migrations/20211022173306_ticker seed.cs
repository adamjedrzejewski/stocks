using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Migrations
{
    public partial class tickerseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickers",
                columns: table => new
                {
                    TickerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickers", x => x.TickerId);
                });

            migrationBuilder.InsertData(
                table: "tickers",
                columns: new[] { "TickerId", "Name" },
                values: new object[,]
                {
                    { -1, "AAPL" },
                    { -72, "CHTR" },
                    { -71, "PM" },
                    { -70, "HON" },
                    { -69, "RY" },
                    { -68, "UNP" },
                    { -67, "SCHW" },
                    { -66, "LOW" },
                    { -65, "INTU" },
                    { -64, "LIN" },
                    { -63, "NEE" },
                    { -62, "MDT" },
                    { -61, "SAP" },
                    { -60, "UPS" },
                    { -59, "SHOP" },
                    { -58, "MCD" },
                    { -57, "T" },
                    { -56, "MS" },
                    { -55, "TXN" },
                    { -54, "NVS" },
                    { -53, "AZN" },
                    { -52, "ABBV" },
                    { -73, "QCOM" },
                    { -51, "SE" },
                    { -74, "AXP" },
                    { -76, "AMD" },
                    { -97, "BA" },
                    { -96, "TGT" },
                    { -95, "PDD" },
                    { -94, "ILMN" },
                    { -93, "BMY" },
                    { -92, "AMT" },
                    { -91, "JD" },
                    { -90, "MRNA" },
                    { -89, "TD" },
                    { -88, "TTE" },
                    { -87, "SBUX" },
                    { -86, "NOW" },
                    { -85, "BBL" },
                    { -84, "RTX" },
                    { -83, "UL" },
                    { -82, "BLK" }
                });

            migrationBuilder.InsertData(
                table: "tickers",
                columns: new[] { "TickerId", "Name" },
                values: new object[,]
                {
                    { -81, "SONY" },
                    { -80, "GS" },
                    { -79, "C" },
                    { -78, "BHP" },
                    { -77, "HDB" },
                    { -75, "TMUS" },
                    { -98, "SNY" },
                    { -50, "INTC" },
                    { -48, "MRK" },
                    { -22, "ASML" },
                    { -21, "PG" },
                    { -20, "MA" },
                    { -19, "ADI" },
                    { -18, "HD" },
                    { -17, "BAC" },
                    { -16, "WMT" },
                    { -15, "UNH" },
                    { -14, "JNJ" },
                    { -13, "IDXX" },
                    { -12, "BABA" },
                    { -11, "V" },
                    { -10, "JPM" },
                    { -9, "NVDA" },
                    { -8, "TSM" },
                    { -7, "TSLA" },
                    { -6, "FB" },
                    { -5, "AMZN" },
                    { -4, "GOOGL" },
                    { -3, "GOOG" },
                    { -2, "MSFT" },
                    { -23, "DIS" },
                    { -49, "WFC" },
                    { -24, "ADBE" },
                    { -26, "CRM" },
                    { -47, "AVGO" },
                    { -46, "COST" },
                    { -45, "CVX" },
                    { -44, "VZ" },
                    { -43, "PEP" },
                    { -42, "ACN" },
                    { -41, "DHR" },
                    { -40, "ABT" }
                });

            migrationBuilder.InsertData(
                table: "tickers",
                columns: new[] { "TickerId", "Name" },
                values: new object[,]
                {
                    { -39, "LLY" },
                    { -38, "CSCO" },
                    { -37, "KO" },
                    { -36, "TM" },
                    { -35, "TMO" },
                    { -34, "PFE" },
                    { -33, "NVO" },
                    { -32, "CMCSA" },
                    { -31, "NKE" },
                    { -30, "XOM" },
                    { -29, "ORCL" },
                    { -28, "NTES" },
                    { -27, "PYPL" },
                    { -25, "NFLX" },
                    { -99, "AMAT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickers");
        }
    }
}
