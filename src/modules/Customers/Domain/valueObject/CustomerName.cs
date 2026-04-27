using System;

namespace SistemadeTiquetess.src.modules.Customers.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que envuelve el nombre del Cliente (Customer).
/// Verifica longitud estructural e integridad básica (evitando inyecciones y nombres vacíos).
/// </summary>
public record CustomerName
{
    public string Value { get; init; }

    private CustomerName(string value)
    {
        Value = value;
    }

    public static CustomerName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del cliente no puede consistir exclusivamente en espacios o estar vacío.");

        string trimmedValue = value.Trim();

        if (trimmedValue.Length < 3 || trimmedValue.Length > 200)
            throw new ArgumentException("El nombre del cliente proporcionado debe poseer una longitud lógica (entre 3 y 200 caracteres).");

        return new CustomerName(trimmedValue);
    }

    public override string ToString() => Value;
}
