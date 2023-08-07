using CsvHelper.Configuration;
using FlightDataExplorer.Models;

namespace FlightDataExplorer.CsvMappings
{
    public class FlightCsvClassMap : ClassMap<Flight>
    {
        public FlightCsvClassMap()
        {
            Map(m => m.Airline);
            Map(m => m.AirlineId).TypeConverter<NullableValueConverter<int>>();
            Map(m => m.SourceAirport);
            Map(m => m.SourceAirportID).TypeConverter<NullableValueConverter<int>>();
            Map(m => m.DestinationAirport);
            Map(m => m.DestinationAirportID).TypeConverter<NullableValueConverter<int>>();
            Map(m => m.Codeshare);
            Map(m => m.Stops);
            Map(m => m.Equipment);
        }
    }
}
