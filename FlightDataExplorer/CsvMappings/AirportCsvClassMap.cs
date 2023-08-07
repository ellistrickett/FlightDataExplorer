using CsvHelper.Configuration;
using FlightDataExplorer.Models;

namespace FlightDataExplorer.CsvMappings
{
    public class AirportCsvClassMap : ClassMap<Airport>
    {
        public AirportCsvClassMap()
        {
            Map(m => m.AirportId);
            Map(m => m.Name);
            Map(m => m.City);
            Map(m => m.Country);
            Map(m => m.IATA);
            Map(m => m.ICAO);
            Map(m => m.Latitude);
            Map(m => m.Longitude);
            Map(m => m.Altitude);
            Map(m => m.Timezone).TypeConverter<NullableValueConverter<double>>();
            Map(m => m.DST);
            Map(m => m.TzDatabaseTimeZone);
            Map(m => m.Type);
            Map(m => m.Source);
        }
    }
}
