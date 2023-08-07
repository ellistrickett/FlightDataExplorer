using FlightDataExplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightDataExplorer.Data
{
    public class DatabaseSeeder
    {
        private readonly FlightDataContext _dbContext;
        private readonly DataImporter _dataImporter;

        public DatabaseSeeder(FlightDataContext dbContext, DataImporter dataImporter)
        {
            _dbContext = dbContext;
            _dataImporter = dataImporter;
        }

        public async Task SeedAsync()
        {
            try
            {
                if (!await _dbContext.Airports.AnyAsync() && !await _dbContext.Flights.AnyAsync())
                {
                    var airports = await _dataImporter.LoadAirportsFromUrl("https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat");
                    var flights = await _dataImporter.LoadFlightsFromUrl("https://raw.githubusercontent.com/jpatokal/openflights/master/data/routes.dat");

                    PopulateAirportIdsIfMissingOrInvalid(flights, airports);

                    _dbContext.Airports.AddRange(airports);
                    _dbContext.Flights.AddRange(flights);

                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while seeding the database: " + ex.Message);
                throw;
            }
        }

        private void PopulateAirportIdsIfMissingOrInvalid(List<Flight> flights, List<Airport> airports)
        {
            foreach (var flight in flights)
            {
                bool destinationAirportExists = airports.Any(a => a.AirportId == flight.DestinationAirportID);

                if (!destinationAirportExists)
                {
                    flight.DestinationAirportID = airports.FirstOrDefault(a => a.IATA == flight.DestinationAirport)?.AirportId;

                    if (flight.DestinationAirportID == null)
                    {
                        flight.DestinationAirportID = airports.FirstOrDefault(a => a.ICAO == flight.DestinationAirport)?.AirportId;
                    }
                }

                bool sourceAirportExists = airports.Any(a => a.AirportId == flight.SourceAirportID);

                if (!sourceAirportExists)
                {
                    flight.SourceAirportID = airports.FirstOrDefault(a => a.IATA == flight.SourceAirport)?.AirportId;

                    if (flight.SourceAirportID == null)
                    {
                        flight.SourceAirportID = airports.FirstOrDefault(a => a.ICAO == flight.SourceAirport)?.AirportId;
                    }
                }
            }
        }
    }
}
