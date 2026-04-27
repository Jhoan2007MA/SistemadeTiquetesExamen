using System;
using SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Infrastructure.Entity;

public class SeatAvailabilityEntity
{
    public Guid Id { get; set; }
    public Guid SeatId { get; set; }
    public Guid FlightId { get; set; }
    public bool IsAvailable { get; set; }

    // Propiedades de navegación
    public virtual SeatEntity Seat { get; set; } = null!;
    public virtual FlightEntity Flight { get; set; } = null!;
}
