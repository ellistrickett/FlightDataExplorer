﻿// <auto-generated />
using System;
using FlightDataExplorer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightDataExplorer.Migrations
{
    [DbContext(typeof(FlightDataContext))]
    [Migration("20230806150448_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightDataExplorer.Models.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirportId"));

                    b.Property<int>("Altitude")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DST")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IATA")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("ICAO")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<double>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<double>("Longitude")
                        .HasPrecision(10, 6)
                        .HasColumnType("float(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Timezone")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TzDatabaseTimeZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightDataExplorer.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int?>("AirlineId")
                        .HasColumnType("int");

                    b.Property<string>("Codeshare")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("DestinationAirport")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("DestinationAirportID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SourceAirport")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("SourceAirportID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Stops")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("DestinationAirportID");

                    b.HasIndex("SourceAirportID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightDataExplorer.Models.Flight", b =>
                {
                    b.HasOne("FlightDataExplorer.Models.Airport", "DestinationAirportNavigation")
                        .WithMany("ArrivalFlights")
                        .HasForeignKey("DestinationAirportID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FlightDataExplorer.Models.Airport", "SourceAirportNavigation")
                        .WithMany("DepartureFlights")
                        .HasForeignKey("SourceAirportID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DestinationAirportNavigation");

                    b.Navigation("SourceAirportNavigation");
                });

            modelBuilder.Entity("FlightDataExplorer.Models.Airport", b =>
                {
                    b.Navigation("ArrivalFlights");

                    b.Navigation("DepartureFlights");
                });
#pragma warning restore 612, 618
        }
    }
}
