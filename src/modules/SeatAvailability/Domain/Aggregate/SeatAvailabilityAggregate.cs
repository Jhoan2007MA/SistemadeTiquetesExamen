using System;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;

public class SeatAvailabilityAggregate
{
    public Guid Id { get; private set; }
    public Guid SeatId { get; private set; }
    public Guid FlightId { get; private set; }
    public bool IsAvailable { get; private set; }

    protected SeatAvailabilityAggregate() { }

    private SeatAvailabilityAggregate(Guid id, Guid seatId, Guid flightId, bool isAvailable)
    {
        Id = id;
        SeatId = seatId;
        FlightId = flightId;
        IsAvailable = isAvailable;
    }

    public static SeatAvailabilityAggregate Create(Guid seatId, Guid flightId)
    {
        return new SeatAvailabilityAggregate(Guid.NewGuid(), seatId, flightId, true);
    }

    public void ToggleAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }
}
