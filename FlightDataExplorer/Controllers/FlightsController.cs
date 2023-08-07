using FlightDataExplorer.Data;
using FlightDataExplorer.Models;
using FlightDataExplorer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDataExplorer.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("directflights")]
        public IActionResult GetDirectFlights(string departureAirportName, string destinationAirportName)
        {
            try
            {
                List<Flight> flights = _flightService.GetDirectFlights(departureAirportName, destinationAirportName);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
