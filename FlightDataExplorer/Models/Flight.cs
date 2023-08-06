using System.ComponentModel.DataAnnotations;

namespace FlightDataExplorer.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required]
        [StringLength(3)]
        public required string Airline { get; set; }

        public int? AirlineId { get; set; }

        [Required]
        [StringLength(4)]
        public required string SourceAirport { get; set; }

        public int? SourceAirportID { get; set; }

        [Required]
        [StringLength(4)]
        public required string DestinationAirport { get; set; }

        public int? DestinationAirportID { get; set; }
        [StringLength(1)]
        public string? Codeshare { get; set; }
        public int Stops { get; set; }

        [Required]
        [StringLength(3)]
        public required string Equipment { get; set; }
    }
}
