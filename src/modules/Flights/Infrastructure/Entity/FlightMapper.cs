using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

public static class FlightMapper
{
    public static FlightEntity ToEntity(Flight aggregate)
    {
        return new FlightEntity
        {
            Id = aggregate.Id,
            FlightNumber = aggregate.FlightNumber,
            StatusId = aggregate.StatusId,
            Origin = aggregate.Origin,
            Destination = aggregate.Destination,
            DepartureDate = aggregate.DepartureDate
        };
    }

    public static Flight ToDomain(FlightEntity entity)
    {
        var aggregate = (Flight)Activator.CreateInstance(typeof(Flight), nonPublic: true)!;
        typeof(Flight).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Flight).GetProperty("FlightNumber")?.SetValue(aggregate, entity.FlightNumber);
        typeof(Flight).GetProperty("StatusId")?.SetValue(aggregate, entity.StatusId);
        typeof(Flight).GetProperty("Origin")?.SetValue(aggregate, entity.Origin);
        typeof(Flight).GetProperty("Destination")?.SetValue(aggregate, entity.Destination);
        typeof(Flight).GetProperty("DepartureDate")?.SetValue(aggregate, entity.DepartureDate);
        return aggregate;
    }
}
