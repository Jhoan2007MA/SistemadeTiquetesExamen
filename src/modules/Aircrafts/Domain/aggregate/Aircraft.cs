using System;

namespace SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;

/// <summary>
/// Representa la entidad raíz (Aggregate Root) de una Aeronave dentro del dominio.
/// Encapsula las reglas de negocio, el estado y las operaciones permitidas sobre una Aeronave.
/// Aplicando el patrón de diseño DDD (Domain-Driven Design).
/// </summary>
public class Aircraft
{
    /// <summary>
    /// Identificador único de la aeronave.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Número de registro o matrícula de la aeronave (ej. HK-5301).
    /// </summary>
    public string RegistrationNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Modelo de la aeronave (ej. Boeing 737, Airbus A320).
    /// </summary>
    public string Model { get; private set; } = string.Empty;

    /// <summary>
    /// Capacidad máxima de pasajeros de la aeronave.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Fabricante de la aeronave (ej. Boeing, Airbus).
    /// </summary>
    public string Manufacturer { get; private set; } = string.Empty;

    /// <summary>
    /// Indica si la aeronave se encuentra activa y disponible para operar vuelos.
    /// </summary>
    public bool IsActive { get; private set; }

    // Constructor protegido sin parámetros, necesario para ORMs como Entity Framework Core.
    protected Aircraft() { }

    // Constructor privado para inicializar el agregado: evita la creación con estado inconsistente.
    private Aircraft(Guid id, string registrationNumber, string model, int capacity, string manufacturer)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        Model = model;
        Capacity = capacity;
        Manufacturer = manufacturer;
        IsActive = true; // Por defecto creamos la aeronave de manera que esté activa
    }

    /// <summary>
    /// Método de fábrica (Factory Method) para crear una nueva instancia de 'Aircraft' aplicando validaciones de dominio.
    /// </summary>
    /// <param name="registrationNumber">La matrícula de la aeronave.</param>
    /// <param name="model">El modelo.</param>
    /// <param name="capacity">La capacidad de pasajeros.</param>
    /// <param name="manufacturer">El fabricante de la aeronave.</param>
    /// <returns>Una nueva instancia válida de Aircraft.</returns>
    public static Aircraft Create(string registrationNumber, string model, int capacity, string manufacturer)
    {
        // Validaciones aplicadas directamente en el dominio (Reglas de negocio críticas)
        if (string.IsNullOrWhiteSpace(registrationNumber))
            throw new ArgumentException("El número de registro es obligatorio.", nameof(registrationNumber));

        if (capacity <= 0)
            throw new ArgumentException("La capacidad debe tener un valor válido y mayor a cero.", nameof(capacity));

        return new Aircraft(Guid.NewGuid(), registrationNumber, model, capacity, manufacturer);
    }

    /// <summary>
    /// Actualiza la información principal de la aeronave mediante un comportamiento de dominio explícito.
    /// </summary>
    public void UpdateDetails(string registrationNumber, string model, int capacity, string manufacturer)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
            throw new ArgumentException("El número de registro no puede estar vacío.", nameof(registrationNumber));
            
        if (capacity <= 0)
            throw new ArgumentException("La capacidad debe ser mayor a cero.", nameof(capacity));

        RegistrationNumber = registrationNumber;
        Model = model;
        Capacity = capacity;
        Manufacturer = manufacturer;
    }

    /// <summary>
    /// Da de baja o inactiva la aeronave (por ejemplo, para que entre en estado de mantenimiento o retiro).
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Reactiva la aeronave para que vuelva a estar disponible después de un mantenimiento.
    /// </summary>
    public void Activate()
    {
        IsActive = true;
    }
}
