using FlightDataExplorer.Models;

namespace FlightDataExplorer.Services
{
    public interface IFlightService
    {
        List<Flight> GetDirectFlights(string departureAirportName, string destinationAirportName);
    }
}
