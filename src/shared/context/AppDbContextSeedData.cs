using System;
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

public static class AppDbContextSeedData
{
    private static readonly Guid IdCountryCol = new("a1000000-0000-0000-0000-000000000001");
    private static readonly Guid IdCountryUs = new("a1000000-0000-0000-0000-000000000002");
    private static readonly Guid IdAirlineMain = new("a1000000-0000-0000-0000-000000000010");
    private static readonly Guid IdApBog = new("a1000000-0000-0000-0000-000000000020");
    private static readonly Guid IdApMia = new("a1000000-0000-0000-0000-000000000021");
    private static readonly Guid IdAircraft1 = new("a1000000-0000-0000-0000-000000000030");
    private static readonly Guid IdFlStProg = new("a1000000-0000-0000-0000-000000000040");
    private static readonly Guid IdFlStFly = new("a1000000-0000-0000-0000-000000000041");
    private static readonly Guid IdFlStLanded = new("a1000000-0000-0000-0000-000000000042");
    private static readonly Guid IdTkStIssued = new("a1000000-0000-0000-0000-000000000050");
    private static readonly Guid IdTkStCancel = new("a1000000-0000-0000-0000-000000000051");
    private static readonly Guid IdRvStPend = new("a1000000-0000-0000-0000-000000000060");
    private static readonly Guid IdRvStConf = new("a1000000-0000-0000-0000-000000000061");
    private static readonly Guid IdPmCard = new("a1000000-0000-0000-0000-000000000070");
    private static readonly Guid IdPmCash = new("a1000000-0000-0000-0000-000000000071");
    private static readonly Guid IdCustomer1 = new("a1000000-0000-0000-0000-000000000080");
    private static readonly Guid IdCustomer2 = new("a1000000-0000-0000-0000-000000000081");
    private static readonly Guid IdContact1 = new("a1000000-0000-0000-0000-000000000090");
    private static readonly Guid IdContact2 = new("a1000000-0000-0000-0000-000000000091");
    private static readonly Guid IdFlight1 = new("a1000000-0000-0000-0000-000000000100");
    private static readonly Guid IdSegment1 = new("a1000000-0000-0000-0000-000000000110");
    private static readonly Guid IdSeat1A = new("a1000000-0000-0000-0000-000000000120");
    private static readonly Guid IdSeat1B = new("a1000000-0000-0000-0000-000000000121");
    private static readonly Guid IdSeat2A = new("a1000000-0000-0000-0000-000000000122");
    private static readonly Guid IdSeat2B = new("a1000000-0000-0000-0000-000000000123");
    private static readonly Guid IdSeAv1 = new("a1000000-0000-0000-0000-000000000130");
    private static readonly Guid IdSeAv2 = new("a1000000-0000-0000-0000-000000000131");
    private static readonly Guid IdSeAv3 = new("a1000000-0000-0000-0000-000000000132");
    private static readonly Guid IdSeAv4 = new("a1000000-0000-0000-0000-000000000133");
    private static readonly Guid IdRes1 = new("a1000000-0000-0000-0000-000000000140");
    private static readonly Guid IdResPass1 = new("a1000000-0000-0000-0000-000000000150");
    private static readonly Guid IdResPass2 = new("a1000000-0000-0000-0000-000000000151");
    private static readonly Guid IdPay1 = new("a1000000-0000-0000-0000-000000000160");
    private static readonly Guid IdPay2 = new("a1000000-0000-0000-0000-000000000161");
    private static readonly Guid IdAssn1 = new("a1000000-0000-0000-0000-000000000170");
    private static readonly Guid IdAssn2 = new("a1000000-0000-0000-0000-000000000171");
    private static readonly Guid IdTicket1 = new("a1000000-0000-0000-0000-000000000180");
    private static readonly Guid IdTicket2 = new("a1000000-0000-0000-0000-000000000181");
    private static readonly DateTime SampleDate = new(2026, 4, 1, 10, 0, 0, DateTimeKind.Utc);

    public static void Apply(ModelBuilder modelBuilder)
    {
        // Catálogos y geografía
        modelBuilder.Entity<CountryEntity>().HasData(
            new CountryEntity
            {
                Id = IdCountryCol,
                Name = "Colombia",
                Code = "CO",
                IsActive = true
            },
            new CountryEntity
            {
                Id = IdCountryUs,
                Name = "Estados Unidos",
                Code = "US",
                IsActive = true
            });

        modelBuilder.Entity<AirlineEntity>().HasData(
            new AirlineEntity
            {
                Id = IdAirlineMain,
                Name = "Avianca",
                Code = "AV",
                IsActive = true
            });

        /*
        modelBuilder.Entity<AirportEntity>().HasData(
            new AirportEntity
            {
                Id = IdApBog,
                IataCode = "BOG",
                Name = "El Dorado",
                City = "Bogotá",
                Country = "Colombia",
                IsActive = true
            },
            new AirportEntity
            {
                Id = IdApMia,
                IataCode = "MIA",
                Name = "Miami International",
                City = "Miami",
                Country = "Estados Unidos",
                IsActive = true
            });
        */

        modelBuilder.Entity<AircraftEntity>().HasData(
            new AircraftEntity
            {
                Id = IdAircraft1,
                RegistrationNumber = "N123AB",
                Model = "A320neo",
                Capacity = 180,
                Manufacturer = "Airbus",
                IsActive = true
            });

        /*
        modelBuilder.Entity<StatusEntity>().HasData(
            new StatusEntity { Id = IdFlStProg, Name = "Programado" },
            new StatusEntity { Id = IdFlStFly, Name = "En vuelo" },
            new StatusEntity { Id = IdFlStLanded, Name = "Aterrizado" });
        */

        modelBuilder.Entity<TicketStatusEntity>().HasData(
            new TicketStatusEntity { Id = IdTkStIssued, Name = "Emitido" },
            new TicketStatusEntity { Id = IdTkStCancel, Name = "Cancelado" });

        modelBuilder.Entity<ReservationStatusEntity>().HasData(
            new ReservationStatusEntity { Id = IdRvStPend, Name = "Pendiente" },
            new ReservationStatusEntity { Id = IdRvStConf, Name = "Confirmada" });

        /*
        modelBuilder.Entity<PaymentMethodEntity>().HasData(
            new PaymentMethodEntity { Id = IdPmCard, Name = "Tarjeta de crédito" },
            new PaymentMethodEntity { Id = IdPmCash, Name = "Efectivo" });
        */

        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity
            {
                Id = IdCustomer1,
                FullName = "María López",
                DocumentNumber = "CC-1234567",
                IsActive = true
            },
            new CustomerEntity
            {
                Id = IdCustomer2,
                FullName = "Juan Pérez",
                DocumentNumber = "CC-7654321",
                IsActive = true
            });

        /*
        modelBuilder.Entity<CustomerContactEntity>().HasData(
            new CustomerContactEntity
            {
                Id = IdContact1,
                CustomerId = IdCustomer1,
                Email = "maria.lopez@example.com",
                PhoneNumber = "+57 300 1112233",
                IsActive = true
            },
            new CustomerContactEntity
            {
                Id = IdContact2,
                CustomerId = IdCustomer2,
                Email = "juan.perez@example.com",
                PhoneNumber = "+57 300 3334455",
                IsActive = true
            });
        */

        modelBuilder.Entity<FlightEntity>().HasData(
            new FlightEntity
            {
                Id = IdFlight1,
                FlightNumber = "AV0101",
                StatusId = IdFlStProg
            });

        /*
        modelBuilder.Entity<SegmentEntity>().HasData(
            new SegmentEntity
            {
                Id = IdSegment1,
                FlightId = IdFlight1,
                OriginAirportId = IdApBog,
                DestinationAirportId = IdApMia
            });
        */

        modelBuilder.Entity<SeatEntity>().HasData(
            new SeatEntity { Id = IdSeat1A, SeatNumber = "1A", Row = "1", Class = "Economy" },
            new SeatEntity { Id = IdSeat1B, SeatNumber = "1B", Row = "1", Class = "Economy" },
            new SeatEntity { Id = IdSeat2A, SeatNumber = "2A", Row = "2", Class = "Economy" },
            new SeatEntity { Id = IdSeat2B, SeatNumber = "2B", Row = "2", Class = "Economy" });

        modelBuilder.Entity<SeatAvailabilityEntity>().HasData(
            new SeatAvailabilityEntity
            {
                Id = IdSeAv1,
                SeatId = IdSeat1A,
                FlightId = IdFlight1,
                IsAvailable = false
            },
            new SeatAvailabilityEntity
            {
                Id = IdSeAv2,
                SeatId = IdSeat1B,
                FlightId = IdFlight1,
                IsAvailable = true
            },
            new SeatAvailabilityEntity
            {
                Id = IdSeAv3,
                SeatId = IdSeat2A,
                FlightId = IdFlight1,
                IsAvailable = true
            },
            new SeatAvailabilityEntity
            {
                Id = IdSeAv4,
                SeatId = IdSeat2B,
                FlightId = IdFlight1,
                IsAvailable = true
            });

        modelBuilder.Entity<ReservationEntity>().HasData(
            new ReservationEntity
            {
                Id = IdRes1,
                CustomerId = IdCustomer1,
                FlightId = IdFlight1,
                ReservationDate = SampleDate,
                StatusId = IdRvStConf
            });

        /*
        modelBuilder.Entity<ReservationPassengerEntity>().HasData(
            new ReservationPassengerEntity
            {
                Id = IdResPass1,
                ReservationId = IdRes1,
                CustomerId = IdCustomer1,
                SeatNumber = "1A"
            },
            new ReservationPassengerEntity
            {
                Id = IdResPass2,
                ReservationId = IdRes1,
                CustomerId = IdCustomer2,
                SeatNumber = "1B"
            });
        */

        /*
        modelBuilder.Entity<PaymentEntity>().HasData(
            new PaymentEntity
            {
                Id = IdPay1,
                ReservationId = IdRes1,
                PaymentMethodId = IdPmCard,
                Amount = 350.00m,
                PaymentDate = SampleDate
            },
            new PaymentEntity
            {
                Id = IdPay2,
                ReservationId = IdRes1,
                PaymentMethodId = IdPmCash,
                Amount = 50.00m,
                PaymentDate = SampleDate.AddHours(1)
            });
        */

        /*
        modelBuilder.Entity<SeatAssignmentEntity>().HasData(
            new SeatAssignmentEntity
            {
                Id = IdAssn1,
                ReservationPassengerId = IdResPass1,
                SeatId = IdSeat1A
            },
            new SeatAssignmentEntity
            {
                Id = IdAssn2,
                ReservationPassengerId = IdResPass2,
                SeatId = IdSeat1B
            });
        */

        /*
        modelBuilder.Entity<TicketEntity>().HasData(
            new TicketEntity
            {
                Id = IdTicket1,
                ReservationPassengerId = IdResPass1,
                StatusId = IdTkStIssued,
                TicketNumber = "TK-BOG-MIA-0001",
                IssueDate = SampleDate
            },
            new TicketEntity
            {
                Id = IdTicket2,
                ReservationPassengerId = IdResPass2,
                StatusId = IdTkStIssued,
                TicketNumber = "TK-BOG-MIA-0002",
                IssueDate = SampleDate
            });
        */
    }
}
