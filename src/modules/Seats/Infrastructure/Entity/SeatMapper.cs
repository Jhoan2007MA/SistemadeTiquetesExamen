using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;

public static class SeatMapper
{
    public static SeatEntity ToEntity(Seat aggregate)
    {
        return new SeatEntity
        {
            Id = aggregate.Id,
            SeatNumber = aggregate.SeatNumber,
            Row = aggregate.Row,
            Class = aggregate.Class
        };
    }

    public static Seat ToDomain(SeatEntity entity)
    {
        var aggregate = (Seat)Activator.CreateInstance(typeof(Seat), nonPublic: true)!;
        typeof(Seat).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Seat).GetProperty("SeatNumber")?.SetValue(aggregate, entity.SeatNumber);
        typeof(Seat).GetProperty("Row")?.SetValue(aggregate, entity.Row);
        typeof(Seat).GetProperty("Class")?.SetValue(aggregate, entity.Class);
        return aggregate;
    }
}
