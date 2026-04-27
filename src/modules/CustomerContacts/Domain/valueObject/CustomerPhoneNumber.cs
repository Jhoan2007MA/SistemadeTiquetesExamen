using System;
using System.Linq;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve y valida la consistencia de un teléfono.
/// </summary>
public record CustomerPhoneNumber
{
    public string Value { get; init; }

    private CustomerPhoneNumber(string value)
    {
        Value = value;
    }

    public static CustomerPhoneNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El número de teléfono es obligatorio si se provee este tipo.");

        string trimmedValue = value.Trim();

        if (trimmedValue.Length < 7 || trimmedValue.Length > 20)
            throw new ArgumentException("El teléfono debe contener tener entre 7 a 20 caracteres.");
            
        // Verificar que contenga al menos algunos dígitos (puede contener simbolos +, -, o espacios)
        if (!trimmedValue.Any(char.IsDigit))
            throw new ArgumentException("El número telefónico debe estar compuesto mayormente por dígitos numéricos.");

        return new CustomerPhoneNumber(trimmedValue);
    }

    public override string ToString() => Value;
}
