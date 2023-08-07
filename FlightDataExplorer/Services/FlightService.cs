using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FlightDataExplorer.Data;
using FlightDataExplorer.Models;
using FlightDataExplorer.Services;

public class FlightService : IFlightService
{
    private readonly FlightDataContext _dbContext;

    public FlightService(FlightDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Flight> GetDirectFlights(string departureAirportName, string destinationAirportName)
    {
        IQueryable<Flight> query = _dbContext.Flights
            .Include(f => f.SourceAirportNavigation)
            .Include(f => f.DestinationAirportNavigation);


        if (!string.IsNullOrEmpty(departureAirportName))
        {
            query = query.Where(f => f.SourceAirportNavigation.Name.Contains(departureAirportName));
        }

        if (!string.IsNullOrEmpty(destinationAirportName))
        {
            query = query.Where(f => f.DestinationAirportNavigation.Name.Contains(destinationAirportName));
        }

        List<Flight> flights = query.ToList();
        return flights;
    }
}
