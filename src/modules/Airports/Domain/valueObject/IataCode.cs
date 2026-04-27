using System;

namespace SistemadeTiquetess.src.modules.Airports.Domain.ValueObject;

/// <summary>
/// Value Object que representa el código IATA de un aeropuerto (ej. BOG, MDE).
/// </summary>
public record IataCode
{
    public string Value { get; init; }

    private IataCode(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Método de fábrica para construir y validar el código IATA.
    /// </summary>
    public static IataCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código IATA no puede estar en blanco o nulo.", nameof(value));

        if (value.Trim().Length != 3)
            throw new ArgumentException("El código IATA debe tener exactamente 3 caracteres.", nameof(value));

        return new IataCode(value.Trim().ToUpper());
    }

    public override string ToString() => Value;
}
