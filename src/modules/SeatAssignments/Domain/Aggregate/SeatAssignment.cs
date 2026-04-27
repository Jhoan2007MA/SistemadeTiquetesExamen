using System;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;

public class SeatAssignment
{
    public Guid Id { get; private set; }
    public Guid ReservationPassengerId { get; private set; }
    public Guid SeatId { get; private set; }

    protected SeatAssignment() { }

    private SeatAssignment(Guid id, Guid resPassId, Guid seatId)
    {
        Id = id;
        ReservationPassengerId = resPassId;
        SeatId = seatId;
    }

    public static SeatAssignment Create(Guid resPassId, Guid seatId)
    {
        return new SeatAssignment(Guid.NewGuid(), resPassId, seatId);
    }

    public void UpdateSeat(Guid seatId)
    {
        SeatId = seatId;
    }
}
