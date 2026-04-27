using System;

namespace SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;

public class FlightSegment
{
    public Guid Id { get; private set; }
    public Guid FlightId { get; private set; }
    public Guid OriginAirportId { get; private set; }
    public Guid DestinationAirportId { get; private set; }

    protected FlightSegment() { }

    private FlightSegment(Guid id, Guid flightId, Guid originId, Guid destinationId)
    {
        Id = id;
        FlightId = flightId;
        OriginAirportId = originId;
        DestinationAirportId = destinationId;
    }

    public static FlightSegment Create(Guid flightId, Guid originId, Guid destinationId)
    {
        return new FlightSegment(Guid.NewGuid(), flightId, originId, destinationId);
    }

    public void UpdateRoute(Guid originId, Guid destinationId)
    {
        OriginAirportId = originId;
        DestinationAirportId = destinationId;
    }
}
