using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightSegments.Infrastructure.Entity;

public static class SegmentMapper
{
    public static SegmentEntity ToEntity(FlightSegment aggregate)
    {
        return new SegmentEntity
        {
            Id = aggregate.Id,
            FlightId = aggregate.FlightId,
            OriginAirportId = aggregate.OriginAirportId,
            DestinationAirportId = aggregate.DestinationAirportId
        };
    }

    public static FlightSegment ToDomain(SegmentEntity entity)
    {
        var aggregate = (FlightSegment)Activator.CreateInstance(typeof(FlightSegment), nonPublic: true)!;
        typeof(FlightSegment).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(FlightSegment).GetProperty("FlightId")?.SetValue(aggregate, entity.FlightId);
        typeof(FlightSegment).GetProperty("OriginAirportId")?.SetValue(aggregate, entity.OriginAirportId);
        typeof(FlightSegment).GetProperty("DestinationAirportId")?.SetValue(aggregate, entity.DestinationAirportId);
        return aggregate;
    }
}
