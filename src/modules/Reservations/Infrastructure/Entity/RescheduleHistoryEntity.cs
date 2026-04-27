using System;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;

public class RescheduleHistoryEntity
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid PreviousFlightId { get; set; }
    public Guid NewFlightId { get; set; }
    public DateTime ChangeDate { get; set; }
    public string Reason { get; set; } = string.Empty;

    // Propiedades de navegación
    public virtual ReservationEntity Reservation { get; set; } = null!;
    public virtual FlightEntity PreviousFlight { get; set; } = null!;
    public virtual FlightEntity NewFlight { get; set; } = null!;
}
