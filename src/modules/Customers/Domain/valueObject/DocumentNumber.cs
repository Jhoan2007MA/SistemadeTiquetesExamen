using System;
using System.Linq;

namespace SistemadeTiquetess.src.modules.Customers.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que estandariza un documento de identidad (pasaporte, DNI, SSN).
/// </summary>
public record DocumentNumber
{
    public string Value { get; init; }

    private DocumentNumber(string value)
    {
        Value = value;
    }

    public static DocumentNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El documento de identificación no debe estar nulo o vacío.");

        string trimmedValue = value.Trim();

        if (trimmedValue.Length < 5 || trimmedValue.Length > 30)
            throw new ArgumentException("La longitud del número de identificación es atípica (debe estar entre 5 y 30).");

        return new DocumentNumber(trimmedValue);
    }

    public override string ToString() => Value;
}
