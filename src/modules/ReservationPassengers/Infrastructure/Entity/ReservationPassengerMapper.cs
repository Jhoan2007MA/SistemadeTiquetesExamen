using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;

public static class ReservationPassengerMapper
{
    public static ReservationPassengerEntity ToEntity(ReservationPassenger aggregate)
    {
        return new ReservationPassengerEntity
        {
            Id = aggregate.Id,
            ReservationId = aggregate.ReservationId,
            CustomerId = aggregate.CustomerId,
            SeatNumber = aggregate.SeatNumber
        };
    }

    public static ReservationPassenger ToDomain(ReservationPassengerEntity entity)
    {
        var aggregate = (ReservationPassenger)Activator.CreateInstance(typeof(ReservationPassenger), nonPublic: true)!;
        typeof(ReservationPassenger).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(ReservationPassenger).GetProperty("ReservationId")?.SetValue(aggregate, entity.ReservationId);
        typeof(ReservationPassenger).GetProperty("CustomerId")?.SetValue(aggregate, entity.CustomerId);
        typeof(ReservationPassenger).GetProperty("SeatNumber")?.SetValue(aggregate, entity.SeatNumber);
        return aggregate;
    }
}
