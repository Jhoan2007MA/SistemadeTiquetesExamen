using System;
using SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.TicketStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Tickets.Infrastructure.Entity;

public class TicketEntity
{
    public Guid Id { get; set; }
    public Guid ReservationPassengerId { get; set; }
    public Guid StatusId { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }

    // Propiedades de navegación
    public virtual ReservationPassengerEntity ReservationPassenger { get; set; } = null!;
    public virtual TicketStatusEntity Status { get; set; } = null!;
}
