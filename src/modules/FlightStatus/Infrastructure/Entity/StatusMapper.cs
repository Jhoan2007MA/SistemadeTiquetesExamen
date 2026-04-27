using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightStatus.Infrastructure.Entity;

public static class StatusMapper
{
    public static StatusEntity ToEntity(FlightStatusAggregate aggregate)
    {
        return new StatusEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name
        };
    }

    public static FlightStatusAggregate ToDomain(StatusEntity entity)
    {
        var aggregate = (FlightStatusAggregate)Activator.CreateInstance(typeof(FlightStatusAggregate), nonPublic: true)!;
        typeof(FlightStatusAggregate).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(FlightStatusAggregate).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        return aggregate;
    }
}
