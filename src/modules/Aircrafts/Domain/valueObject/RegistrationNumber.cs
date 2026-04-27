using System;

namespace SistemadeTiquetess.src.modules.Aircrafts.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que representa la matrícula o número de registro de una aeronave.
/// Los "records" (registros) en C# son perfectos para ValueObjects porque proveen inmutabilidad total 
/// y comparación por valor (estructural) automáticamente en vez de por referencia de memoria.
/// </summary>
public record RegistrationNumber
{
    /// <summary>
    /// Valor textual de la matrícula.
    /// </summary>
    public string Value { get; init; }

    // Constructor privado para forzar al desarrollador a usar el método estructurado 'Create'
    private RegistrationNumber(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Método de fábrica que encapsula nuestras reglas y lógicas de validación para construir un número de registro.
    /// </summary>
    /// <param name="value">La cadena de texto a validar.</param>
    /// <returns>Instancia inmutable de RegistrationNumber.</returns>
    /// <exception cref="ArgumentException">Se dispara si los valores no cumplen con las condiciones del negocio.</exception>
    public static RegistrationNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El número de matrícula no puede estar en blanco o nulo.", nameof(value));

        // Aquí podrías agregar comprobaciones complejas con Regex para obligar un formato (ej. "HK-" seguido de números).
        // Por ahora lo limpiamos y lo pasamos a mayúsculas como regla de estandarización básica.
        return new RegistrationNumber(value.Trim().ToUpper());
    }

    public override string ToString() => Value;
}
