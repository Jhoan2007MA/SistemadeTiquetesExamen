using System;
using System.Text.RegularExpressions;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve y valida estructuralmente un correo electrónico de cliente.
/// </summary>
public record CustomerEmail
{
    public string Value { get; init; }

    private CustomerEmail(string value)
    {
        Value = value;
    }

    public static CustomerEmail Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El correo de contacto no puede ser nulo o compuesto de puros espacios.");

        string trimmedValue = value.Trim();

        // Regex simple para asegurar una sintaxis de correo razonable
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(trimmedValue))
            throw new ArgumentException("El formato del correo electrónico provisto no es válido.");

        return new CustomerEmail(trimmedValue);
    }

    public override string ToString() => Value;
}
