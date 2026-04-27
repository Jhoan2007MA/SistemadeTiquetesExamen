using System;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;

public class ReservationPassengerEntity
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid CustomerId { get; set; }
    public string SeatNumber { get; set; } = string.Empty;

    // Propiedades de navegación
    public virtual ReservationEntity Reservation { get; set; } = null!;
    public virtual CustomerEntity Customer { get; set; } = null!;
}
