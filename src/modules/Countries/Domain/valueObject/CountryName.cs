using System;

namespace SistemadeTiquetess.src.modules.Countries.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve el nombre del País.
/// Verifica longitudes lógicas y asegura que no pueda setearse en blanco.
/// </summary>
public record CountryName
{
    public string Value { get; init; }

    private CountryName(string value)
    {
        Value = value;
    }

    public static CountryName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del país es de carácter obligatorio.");

        string trimmedValue = value.Trim();

        if (trimmedValue.Length > 150)
            throw new ArgumentException("El nombre del país provisto es anormalmente largo.");

        return new CountryName(trimmedValue);
    }

    public override string ToString() => Value;
}
