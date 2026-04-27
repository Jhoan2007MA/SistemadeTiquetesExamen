using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Tickets.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Tickets.Infrastructure.Entity;

public static class TicketMapper
{
    public static TicketEntity ToEntity(Ticket aggregate)
    {
        return new TicketEntity
        {
            Id = aggregate.Id,
            ReservationPassengerId = aggregate.ReservationPassengerId,
            StatusId = aggregate.StatusId,
            TicketNumber = aggregate.TicketNumber,
            IssueDate = aggregate.IssueDate
        };
    }

    public static Ticket ToDomain(TicketEntity entity)
    {
        var aggregate = (Ticket)Activator.CreateInstance(typeof(Ticket), nonPublic: true)!;
        typeof(Ticket).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Ticket).GetProperty("ReservationPassengerId")?.SetValue(aggregate, entity.ReservationPassengerId);
        typeof(Ticket).GetProperty("StatusId")?.SetValue(aggregate, entity.StatusId);
        typeof(Ticket).GetProperty("TicketNumber")?.SetValue(aggregate, entity.TicketNumber);
        typeof(Ticket).GetProperty("IssueDate")?.SetValue(aggregate, entity.IssueDate);
        return aggregate;
    }
}
