using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Infrastructure.Entity;

public static class ReservationStatusMapper
{
    public static ReservationStatusEntity ToEntity(ReservationStatus aggregate)
    {
        return new ReservationStatusEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name
        };
    }

    public static ReservationStatus ToDomain(ReservationStatusEntity entity)
    {
        var aggregate = (ReservationStatus)Activator.CreateInstance(typeof(ReservationStatus), nonPublic: true)!;
        typeof(ReservationStatus).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(ReservationStatus).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        return aggregate;
    }
}
