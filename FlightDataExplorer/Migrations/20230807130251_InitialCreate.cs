using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDataExplorer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ICAO = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Latitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<double>(type: "float(10)", precision: 10, scale: 6, nullable: false),
                    Altitude = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<double>(type: "float", nullable: true),
                    DST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TzDatabaseTimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: true),
                    SourceAirport = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    SourceAirportID = table.Column<int>(type: "int", nullable: true),
                    DestinationAirport = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DestinationAirportID = table.Column<int>(type: "int", nullable: true),
                    Codeshare = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Stops = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DestinationAirportID",
                        column: x => x.DestinationAirportID,
                        principalTable: "Airports",
                        principalColumn: "AirportId");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_SourceAirportID",
                        column: x => x.SourceAirportID,
                        principalTable: "Airports",
                        principalColumn: "AirportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationAirportID",
                table: "Flights",
                column: "DestinationAirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SourceAirportID",
                table: "Flights",
                column: "SourceAirportID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
