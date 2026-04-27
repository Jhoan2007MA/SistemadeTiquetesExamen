using System;

namespace SistemadeTiquetess.src.modules.Airlines.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que encapsula de forma inmutable el Código de una aerolínea (ej. IATA o ICAO).
/// Garantiza la estandarización (mayúsculas, sin espacios) y evita códigos nulos o irreales.
/// </summary>
public record AirlineCode
{
    /// <summary>
    /// Valor textual oficial del código.
    /// </summary>
    public string Value { get; init; }

    private AirlineCode(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Construye y valida el código de la aerolínea de acuerdo a la regulación del negocio.
    /// </summary>
    public static AirlineCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código de la aerolínea no puede estar vacío o en blanco.");

        value = value.Trim().ToUpper();

        // IATA = 2 chars (ej. AV, LA). ICAO = 3 chars (ej. AVA, LAN).
        if (value.Length < 2 || value.Length > 3)
            throw new ArgumentException("Un código de aerolínea válido suele contener entre 2 y 3 caracteres.");

        return new AirlineCode(value);
    }

    public override string ToString() => Value;
}
