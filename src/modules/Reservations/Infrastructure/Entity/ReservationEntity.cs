using System;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.ReservationsStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;

public class ReservationEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid FlightId { get; set; }
    public DateTime ReservationDate { get; set; }
    public Guid StatusId { get; set; }

    // Propiedades de navegación
    public virtual CustomerEntity Customer { get; set; } = null!;
    public virtual FlightEntity Flight { get; set; } = null!;
    public virtual ReservationStatusEntity Status { get; set; } = null!;
}
