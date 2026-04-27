using System;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;

public class WaitlistEntity
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid FlightId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; } = "Waiting"; // "Waiting", "Promoted", "Cancelled"

    // Propiedades de navegación
    public virtual ReservationEntity Reservation { get; set; } = null!;
    public virtual FlightEntity Flight { get; set; } = null!;
}
