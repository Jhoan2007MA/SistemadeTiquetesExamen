using System;
using SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Infrastructure.Entity;

public class SeatAssignmentEntity
{
    public Guid Id { get; set; }
    public Guid ReservationPassengerId { get; set; }
    public Guid SeatId { get; set; }

    // Propiedades de navegación
    public virtual ReservationPassengerEntity ReservationPassenger { get; set; } = null!;
    public virtual SeatEntity Seat { get; set; } = null!;
}
