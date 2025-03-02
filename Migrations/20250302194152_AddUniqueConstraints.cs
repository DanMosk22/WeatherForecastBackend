using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherForecast.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Forecasts_LocationID",
                table: "Forecasts");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Lat_Lon",
                table: "Locations",
                columns: new[] { "Lat", "Lon" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_LocationID_Date",
                table: "Forecasts",
                columns: new[] { "LocationID", "Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_Lat_Lon",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Forecasts_LocationID_Date",
                table: "Forecasts");

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_LocationID",
                table: "Forecasts",
                column: "LocationID");
        }
    }
}
