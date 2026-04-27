using System;

namespace SistemadeTiquetess.src.modules.Tickets.Domain.Aggregate;

public class Ticket
{
    public Guid Id { get; private set; }
    public Guid ReservationPassengerId { get; private set; }
    public Guid StatusId { get; private set; }
    public string TicketNumber { get; private set; } = string.Empty;
    public DateTime IssueDate { get; private set; }

    protected Ticket() { }

    private Ticket(Guid id, Guid resPassId, Guid statusId, string ticketNumber, DateTime issueDate)
    {
        Id = id;
        ReservationPassengerId = resPassId;
        StatusId = statusId;
        TicketNumber = ticketNumber;
        IssueDate = issueDate;
    }

    public static Ticket Create(Guid resPassId, Guid statusId, string ticketNumber)
    {
        return new Ticket(Guid.NewGuid(), resPassId, statusId, ticketNumber.Trim().ToUpper(), DateTime.UtcNow);
    }

    public void UpdateStatus(Guid statusId)
    {
        StatusId = statusId;
    }
}
