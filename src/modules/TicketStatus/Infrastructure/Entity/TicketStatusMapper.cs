using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.TicketStatus.Infrastructure.Entity;

public static class TicketStatusMapper
{
    public static TicketStatusEntity ToEntity(TicketStatusAggregate aggregate)
    {
        return new TicketStatusEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name
        };
    }

    public static TicketStatusAggregate ToDomain(TicketStatusEntity entity)
    {
        var aggregate = (TicketStatusAggregate)Activator.CreateInstance(typeof(TicketStatusAggregate), nonPublic: true)!;
        typeof(TicketStatusAggregate).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(TicketStatusAggregate).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        return aggregate;
    }
}
