using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Infrastructure.Entity;

public static class SeatAvailabilityMapper
{
    public static SeatAvailabilityEntity ToEntity(SeatAvailabilityAggregate aggregate)
    {
        return new SeatAvailabilityEntity
        {
            Id = aggregate.Id,
            SeatId = aggregate.SeatId,
            FlightId = aggregate.FlightId,
            IsAvailable = aggregate.IsAvailable
        };
    }

    public static SeatAvailabilityAggregate ToDomain(SeatAvailabilityEntity entity)
    {
        var aggregate = (SeatAvailabilityAggregate)Activator.CreateInstance(typeof(SeatAvailabilityAggregate), nonPublic: true)!;
        typeof(SeatAvailabilityAggregate).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(SeatAvailabilityAggregate).GetProperty("SeatId")?.SetValue(aggregate, entity.SeatId);
        typeof(SeatAvailabilityAggregate).GetProperty("FlightId")?.SetValue(aggregate, entity.FlightId);
        typeof(SeatAvailabilityAggregate).GetProperty("IsAvailable")?.SetValue(aggregate, entity.IsAvailable);
        return aggregate;
    }
}
