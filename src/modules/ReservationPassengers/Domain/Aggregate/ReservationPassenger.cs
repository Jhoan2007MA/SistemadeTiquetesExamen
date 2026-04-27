using System;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;

public class ReservationPassenger
{
    public Guid Id { get; private set; }
    public Guid ReservationId { get; private set; }
    public Guid CustomerId { get; private set; }
    public string SeatNumber { get; private set; } = string.Empty;

    protected ReservationPassenger() { }

    private ReservationPassenger(Guid id, Guid resId, Guid custId, string seat)
    {
        Id = id;
        ReservationId = resId;
        CustomerId = custId;
        SeatNumber = seat;
    }

    public static ReservationPassenger Create(Guid resId, Guid custId, string seat)
    {
        return new ReservationPassenger(Guid.NewGuid(), resId, custId, seat.Trim().ToUpper());
    }

    public void UpdateSeat(string seat)
    {
        SeatNumber = seat.Trim().ToUpper();
    }
}
