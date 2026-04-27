using System;

namespace SistemadeTiquetess.src.modules.Aircrafts.Domain.ValueObject;

/// <summary>
/// Objeto de Valor (Value Object) que encapsula de forma inmutable la capacidad de asientos/pasajeros
/// de una aeronave, garantizando siempre que los valores dentro de este tipo tengan coherencia física y de negocio.
/// </summary>
public record Capacity
{
    /// <summary>
    /// Cantidad numérica de la capacidad.
    /// </summary>
    public int Value { get; init; }

    // Constructor privado para evitar instanciaciones inconsistentes directas.
    private Capacity(int value)
    {
        Value = value;
    }

    /// <summary>
    /// Construye y valida una capacidad para asegurar la integridad de la información del dominio.
    /// </summary>
    /// <param name="value">Número total de pasajeros soportables.</param>
    /// <returns>Instancia inmutable validada de Capacity.</returns>
    /// <exception cref="ArgumentException">Se lanza si el número no tiene sentido lógico.</exception>
    public static Capacity Create(int value)
    {
        // 1. Regla: Incoherencia - No podemos tener aeronaves de cero o capacidad negativa.
        if (value <= 0)
            throw new ArgumentException("La capacidad mínima de pasajeros debe ser estrictamente mayor que cero.", nameof(value));

        // 2. Regla: Límite extremo (Ejemplo: Un A380 modificado a tope es de menos de ~900).
        if (value > 1200)
            throw new ArgumentException("El valor asignado sobrepasa los estándares estructurales y comerciales del mundo real.", nameof(value));

        return new Capacity(value);
    }

    // Sobrescritura opcional para evitar imprimir "Capacity { Value = 150 }" y que solo devuelva "150".
    public override string ToString() => Value.ToString();
}
