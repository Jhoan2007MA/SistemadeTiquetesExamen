using System;

namespace SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;

public class FlightStatusAggregate
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    protected FlightStatusAggregate() { }

    private FlightStatusAggregate(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static FlightStatusAggregate Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del estado de vuelo es requerido.");

        return new FlightStatusAggregate(Guid.NewGuid(), name.Trim());
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del estado no puede estar vacío.");

        Name = name.Trim();
    }
}
