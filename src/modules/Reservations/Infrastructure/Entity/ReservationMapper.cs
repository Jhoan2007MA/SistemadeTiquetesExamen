using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;

public static class ReservationMapper
{
    public static ReservationEntity ToEntity(Reservation aggregate)
    {
        return new ReservationEntity
        {
            Id = aggregate.Id,
            CustomerId = aggregate.CustomerId,
            FlightId = aggregate.FlightId,
            ReservationDate = aggregate.ReservationDate,
            StatusId = aggregate.Status == "Confirmada" 
                ? new Guid("a1000000-0000-0000-0000-000000000061") 
                : new Guid("a1000000-0000-0000-0000-000000000060")
        };
    }

    public static Reservation ToDomain(ReservationEntity entity)
    {
        var aggregate = (Reservation)Activator.CreateInstance(typeof(Reservation), nonPublic: true)!;
        typeof(Reservation).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Reservation).GetProperty("CustomerId")?.SetValue(aggregate, entity.CustomerId);
        typeof(Reservation).GetProperty("FlightId")?.SetValue(aggregate, entity.FlightId);
        typeof(Reservation).GetProperty("ReservationDate")?.SetValue(aggregate, entity.ReservationDate);
        
        string statusName = entity.StatusId == new Guid("a1000000-0000-0000-0000-000000000061") 
            ? "Confirmada" 
            : "Pendiente";
        typeof(Reservation).GetProperty("Status")?.SetValue(aggregate, statusName);
        
        return aggregate;
    }
}
