using System;

namespace SistemadeTiquetess.src.modules.Countries.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve el código ISO del País.
/// Asegura formato y longitud correcta (ej: CO, US).
/// </summary>
public record CountryCode
{
    public string Value { get; init; }

    private CountryCode(string value)
    {
        Value = value;
    }

    public static CountryCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código del país es obligatorio.");

        string trimmedValue = value.Trim().ToUpper();

        if (trimmedValue.Length < 2 || trimmedValue.Length > 3)
            throw new ArgumentException("El código del país debe tener entre 2 y 3 caracteres (formato ISO).");

        return new CountryCode(trimmedValue);
    }

    public override string ToString() => Value;
}
