using System.ComponentModel.DataAnnotations;

namespace FlightDataExplorer.Models
{
    public class Airport
    {
        [Key]
        public int AirportId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Country { get; set; }
        [StringLength(3)]
        public string? IATA { get; set; }
        [StringLength(4)]
        public string? ICAO { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public double? Timezone { get; set; }

        [Required]
        public required string DST { get; set; }

        [Required]
        public required string? TzDatabaseTimeZone { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Source { get; set; }
    }
}
