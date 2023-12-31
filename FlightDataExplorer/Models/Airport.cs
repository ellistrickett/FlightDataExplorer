﻿using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [Range(-90, 90, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public double? Timezone { get; set; }

        [Required]
        public required string DST { get; set; }

        [Required]
        public required string TzDatabaseTimeZone { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Source { get; set; }

        [InverseProperty("SourceAirportNavigation")]
        [Ignore]
        [JsonIgnore]
        public ICollection<Flight>? DepartureFlights { get; set; }

        [InverseProperty("DestinationAirportNavigation")]
        [Ignore]
        [JsonIgnore]
        public ICollection<Flight>? ArrivalFlights { get; set; }
    }
}
