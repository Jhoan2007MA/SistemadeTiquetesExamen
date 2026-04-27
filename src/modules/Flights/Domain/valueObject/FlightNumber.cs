using System;

namespace SistemadeTiquetess.src.modules.Flights.Domain.ValueObject;

public record FlightNumber
{
    public string Value { get; init; }

    private FlightNumber(string value) => Value = value;

    public static FlightNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El número de vuelo no puede estar vacío.");

        return new FlightNumber(value.Trim().ToUpper());
    }

    public override string ToString() => Value;
}
