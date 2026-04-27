using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Infrastructure.Entity;

public static class SeatAssignmentMapper
{
    public static SeatAssignmentEntity ToEntity(SeatAssignment aggregate)
    {
        return new SeatAssignmentEntity
        {
            Id = aggregate.Id,
            ReservationPassengerId = aggregate.ReservationPassengerId,
            SeatId = aggregate.SeatId
        };
    }

    public static SeatAssignment ToDomain(SeatAssignmentEntity entity)
    {
        var aggregate = (SeatAssignment)Activator.CreateInstance(typeof(SeatAssignment), nonPublic: true)!;
        typeof(SeatAssignment).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(SeatAssignment).GetProperty("ReservationPassengerId")?.SetValue(aggregate, entity.ReservationPassengerId);
        typeof(SeatAssignment).GetProperty("SeatId")?.SetValue(aggregate, entity.SeatId);
        return aggregate;
    }
}
