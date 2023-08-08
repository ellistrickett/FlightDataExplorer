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
        return _dbContext.Airports
            .Where(a => a.Name == departureAirportName)
            .Include(a => a.ArrivalFlights)
                .ThenInclude(f => f.SourceAirportNavigation)
            .Include(a => a.DepartureFlights)
                .ThenInclude(f => f.DestinationAirportNavigation)
            .SelectMany(a => a.DepartureFlights.Where(df => df.DestinationAirportNavigation.Name == destinationAirportName))
            .ToList();
    }
}
