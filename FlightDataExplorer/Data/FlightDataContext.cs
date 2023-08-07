using FlightDataExplorer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FlightDataExplorer.Data
{
    public class FlightDataContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public FlightDataContext(DbContextOptions<FlightDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                .Property(a => a.AirportId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(m => m.Latitude).HasPrecision(9, 6);
                entity.Property(m => m.Longitude).HasPrecision(10, 6);
            });

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.SourceAirportNavigation)
                .WithMany(a => a.DepartureFlights)
                .HasForeignKey(f => f.SourceAirportID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DestinationAirportNavigation)
                .WithMany(a => a.ArrivalFlights)
                .HasForeignKey(f => f.DestinationAirportID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Airport>()
                .HasMany(a => a.DepartureFlights)
                .WithOne(f => f.SourceAirportNavigation)
                .HasForeignKey(f => f.SourceAirportID);

            modelBuilder.Entity<Airport>()
                .HasMany(a => a.ArrivalFlights)
                .WithOne(f => f.DestinationAirportNavigation)
                .HasForeignKey(f => f.DestinationAirportID);

        }
    }
}
