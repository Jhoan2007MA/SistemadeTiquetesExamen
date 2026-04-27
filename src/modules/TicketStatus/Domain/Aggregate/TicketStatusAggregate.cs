using System;

namespace SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;

public class TicketStatusAggregate
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    protected TicketStatusAggregate() { }

    private TicketStatusAggregate(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static TicketStatusAggregate Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del estado de tiquete es requerido.");
        return new TicketStatusAggregate(Guid.NewGuid(), name.Trim());
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío.");
        Name = name.Trim();
    }
}
