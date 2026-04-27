using System;

namespace SistemadeTiquetess.src.modules.Airlines.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve el nombre de la Aerolínea.
/// Verifica longitudes lógicas y asegura que no pueda setearse en blanco.
/// </summary>
public record AirlineName
{
    public string Value { get; init; }

    private AirlineName(string value)
    {
        Value = value;
    }

    public static AirlineName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la aerolínea es de carácter obligatorio.");

        string trimmedValue = value.Trim();

        if (trimmedValue.Length > 150)
            throw new ArgumentException("El nombre de la aerolínea provisto es anormalmente largo.");

        return new AirlineName(trimmedValue);
    }

    public override string ToString() => Value;
}
