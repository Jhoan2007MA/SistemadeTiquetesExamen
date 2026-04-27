using System;

namespace SistemadeTiquetess.src.modules.FlightStatus.Domain.ValueObject;

public record StatusName
{
    public string Value { get; init; }

    private StatusName(string value) => Value = value;

    public static StatusName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del estado no puede estar vacío.");

        return new StatusName(value.Trim());
    }

    public override string ToString() => Value;
}
