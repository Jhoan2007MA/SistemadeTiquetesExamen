using System;

namespace SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;

public class Reservation
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid FlightId { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public string Status { get; private set; } = "Pending";

    protected Reservation() { }

    private Reservation(Guid id, Guid customerId, Guid flightId, DateTime resDate, string status)
    {
        Id = id;
        CustomerId = customerId;
        FlightId = flightId;
        ReservationDate = resDate;
        Status = status;
    }

    public static Reservation Create(Guid customerId, Guid flightId)
    {
        return new Reservation(Guid.NewGuid(), customerId, flightId, DateTime.UtcNow, "Confirmed");
    }

    public void UpdateStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("El estado de la reserva no puede estar vacío.");
        
        Status = status.Trim();
    }
}
