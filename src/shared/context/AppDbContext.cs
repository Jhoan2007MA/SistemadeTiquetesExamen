using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Entity;
using SistemadeTiquetess.src.modules.Airlines.infrastructure.Entity;
// using SistemadeTiquetess.src.modules.Airports.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Countries.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.CustomerContacts.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.FlightSegments.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.FlightStatus.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.Payments.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.ReservationsStatus.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.SeatAssignments.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.SeatAvailability.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;
// using SistemadeTiquetess.src.modules.Tickets.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.TicketStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.shared.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AirlineEntity> Airlines => Set<AirlineEntity>();
    // public DbSet<AirportEntity> Airports => Set<AirportEntity>();
    public DbSet<CountryEntity> Countries => Set<CountryEntity>();
    public DbSet<AircraftEntity> Aircrafts => Set<AircraftEntity>();
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    // public DbSet<CustomerContactEntity> CustomerContacts => Set<CustomerContactEntity>();
    public DbSet<FlightEntity> Flights => Set<FlightEntity>();
    // public DbSet<SegmentEntity> Segments => Set<SegmentEntity>();
    // public DbSet<StatusEntity> FlightStatuses => Set<StatusEntity>();
    // public DbSet<PaymentMethodEntity> PaymentMethods => Set<PaymentMethodEntity>();
    // public DbSet<PaymentEntity> Payments => Set<PaymentEntity>();
    public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();
    // public DbSet<ReservationPassengerEntity> ReservationPassengers => Set<ReservationPassengerEntity>();
    public DbSet<ReservationStatusEntity> ReservationStatuses => Set<ReservationStatusEntity>();
    public DbSet<SeatEntity> Seats => Set<SeatEntity>();
    // public DbSet<SeatAssignmentEntity> SeatAssignments => Set<SeatAssignmentEntity>();
    // public DbSet<SeatAvailabilityEntity> SeatAvailabilities => Set<SeatAvailabilityEntity>();
    // public DbSet<TicketEntity> Tickets => Set<TicketEntity>();
    // public DbSet<TicketStatusEntity> TicketStatuses => Set<TicketStatusEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        AppDbContextSeedData.Apply(modelBuilder);
    }
}
